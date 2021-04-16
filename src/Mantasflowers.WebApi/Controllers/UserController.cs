using FirebaseAdmin.Auth;
using Mantasflowers.Contracts.Firebase.Request;
using Mantasflowers.Contracts.Firebase.Response;
using Mantasflowers.Contracts.Responses;
using Mantasflowers.Services.FirebaseService;
using Mantasflowers.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mantasflowers.WebApi.Controllers
{
    [ApiController]
    [Route("/userbase")]
    public class UserController : ControllerBase
    {
        private readonly FirebaseService _fbService;

        public UserController(FirebaseService fbService)
        {
            _fbService = fbService;
        }

        /// <summary>
        /// A sign-in endpoint.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("tokens")]
        [ProducesResponseType(typeof(PostTokensResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTokensAsync([FromBody] PostCredentialsRequest request)
        {
            try
            {
                var response = await _fbService.GetTokensAsync(request.Email, request.Password);
                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException && !string.IsNullOrEmpty(ex.Message))
                {
                    var errorData = new { error = new { code = 0, message = "errorid" } };
                    errorData = JsonConvert.DeserializeAnonymousType(ex.Message, errorData);

                    return Unauthorized(errorData?.error?.message ?? ResponseMsg.NotFound);
                }

                return BadRequest(ResponseMsg.NotFound);
            }
        }

        [HttpPost("refresh-id-token")]
        [ProducesResponseType(typeof(PostTokensResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshIdTokenAsync([FromBody] PostRefreshTokenRequest request)
        {
            string responseData = string.Empty;
            try
            {
                var response = await _fbService.RefreshIdTokenAsync(request.RefreshToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException && !string.IsNullOrEmpty(ex.Message))
                {
                    var errorData = new { error = new { code = 0, message = "errorid" } };
                    errorData = JsonConvert.DeserializeAnonymousType(ex.Message, errorData);

                    return BadRequest(errorData?.error?.message ?? ResponseMsg.NotFound);
                }

                return BadRequest(ResponseMsg.NotFound);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost("revoke-refresh-token")]
        public IActionResult RevokeRefreshTokens([FromBody] PostUidRequest request)
        {
            return HandleException(async () =>
            {
                await _fbService.RevokeRefreshTokensAsync(request.Uid);
                return Ok(ResponseMsg.RefreshTokenRevoked);
            });
        }

        [Authorize(Roles = "admin")]
        [HttpPost("custom-role")]
        public IActionResult SetCustomUserRole([FromBody] PostRoleRequest request)
        {
            var claims = new Dictionary<string, object>()
            {
                { ClaimTypes.Role, request.Role.ToLower() },
            };

            return HandleException(async () =>
            {
                await _fbService.SetCustomUserClaimsAsync(request.Uid, claims);
                return Ok(ResponseMsg.CustomClaimSet);
            });
        }

        [HttpPost("create-user")]
        public IActionResult CreateUser([FromBody] PostCredentialsRequest request)
        {
            return HandleException(async () =>
            {
                var user = await _fbService.CreateUserAsync(request.Email, request.Password);
                return Ok(user);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">For testing purposes Uid: G46RSuLIvbUjaWJyokcCMDSCeVj1</param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost("user/by-uid")]
        public IActionResult GetUserByUid([FromBody] PostUidRequest request)
        {
            return HandleException(async () =>
            {
                var user = await _fbService.GetUserByUidAsync(request.Uid);
                return Ok(user);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email">For testing purposes: johnny@john.jo</param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet("user/by-email")]
        public IActionResult GetUserByEmail(string email)
        {
            return HandleException(async () =>
            {
                var user = await _fbService.GetUserByEmailAsync(email);
                return Ok(user);
            });
        }

        [Authorize]
        [HttpPost("update-user/email")]
        public IActionResult UpdateUserEmail([FromBody] PostUpdateEmailRequest request)
        {
            return HandleException(async () =>
            {
                var user = await _fbService.UpdateUserEmailAsync(request.Uid, request.Email);
                return Ok(user);
            });
        }

        [Authorize]
        [HttpPost("update-user/password")]
        public IActionResult UpdateUserPassword([FromBody] PostUpdatePasswordRequest request)
        {
            return HandleException(async () =>
            {
                var user = await _fbService.UpdateUserPasswordAsync(request.Uid, request.Password);
                return Ok(user);
            });
        }

        [Authorize(Roles = "admin")]
        [HttpPost("delete-user")]
        public IActionResult DeleteUserByUid([FromBody] PostUidRequest request)
        {
            return HandleException(async () =>
            {
                await _fbService.DeleteUserByUidAsync(request.Uid);
                return Ok(ResponseMsg.UserDeleted);
            });
        }

        private IActionResult HandleException(Func<Task<IActionResult>> tryBlock)
        {
            try
            {
                return tryBlock.Invoke().Result;
            }
            catch (Exception ex)
            {
                if (ex.InnerException is FirebaseAuthException iex)
                {
                    if (iex.Message.ContainsEnclosing('(', ')'))
                    {
                        return BadRequest(iex.Message.SubstringWithin('(', ')'));
                    }

                    return BadRequest(Enum.GetName(typeof(AuthError), iex.AuthErrorCode));
                }

                return BadRequest(ResponseMsg.NotFound);
            }
        }
    }
}
