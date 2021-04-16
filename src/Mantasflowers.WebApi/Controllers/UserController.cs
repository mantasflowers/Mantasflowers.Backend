using FirebaseAdmin.Auth;
using Mantasflowers.Services.FirebaseService;
using Mantasflowers.WebApi.Extensions;
using Mantasflowers.WebApi.Responses;
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
    [Route("/firebase")]
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
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("get-tokens")]
        [ProducesResponseType(typeof(GetTokensResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTokensAsync(string email, string password)
        {
            string responseData = string.Empty;
            try
            {
                var response = await _fbService.GetTokensAsync(email, password);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        [HttpGet("refresh-id-token")]
        [ProducesResponseType(typeof(GetTokensResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshIdTokenAsync(string refreshToken)
        {
            string responseData = string.Empty;
            try
            {
                var response = await _fbService.RefreshIdTokenAsync(refreshToken);

                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException && !string.IsNullOrEmpty(responseData))
                {
                    var errorData = new { error = new { code = 0, message = "errorid" } };
                    errorData = JsonConvert.DeserializeAnonymousType(responseData, errorData);

                    return Unauthorized(errorData?.error?.message ?? ResponseMsg.NotFound);
                }

                return BadRequest(ResponseMsg.NotFound);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet("revoke-refresh-token")]
        public IActionResult RevokeRefreshTokens(string uid)
        {
            return HandleException(async () =>
            {
                await _fbService.RevokeRefreshTokensAsync(uid);
                return Ok(ResponseMsg.RefreshTokenRevoked);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet("custom-role")]
        public IActionResult SetCustomUserRole(string uid, string role)
        {
            var claims = new Dictionary<string, object>()
            {
                { ClaimTypes.Role, role },
            };

            return HandleException(async () =>
            {
                await _fbService.SetCustomUserClaimsAsync(uid, claims);
                return Ok(ResponseMsg.CustomClaimSet);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("create-user")]
        public IActionResult CreateUser(string email, string password)
        {
            return HandleException(async () =>
            {
                var user = await _fbService.CreateUserAsync(email, password);
                return Ok(user);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid">For testing purposes: G46RSuLIvbUjaWJyokcCMDSCeVj1</param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet("get-user/by-uid")]
        public IActionResult GetUserByUid(string uid)
        {
            return HandleException(async () =>
            {
                var user = await _fbService.GetUserByUidAsync(uid);
                return Ok(user);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email">For testing purposes: johnny@john.jo</param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet("get-user/by-email")]
        public IActionResult GetUserByEmail(string email)
        {
            return HandleException(async () =>
            {
                var user = await _fbService.GetUserByEmailAsync(email);
                return Ok(user);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("update-user/email")]
        public IActionResult UpdateUserEmail(string uid, string email)
        {
            return HandleException(async () =>
            {
                var user = await _fbService.UpdateUserEmailAsync(uid, email);
                return Ok(user);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("update-user/password")]
        public IActionResult UpdateUserPassword(string uid, string password)
        {
            return HandleException(async () =>
            {
                var user = await _fbService.UpdateUserPasswordAsync(uid, password);
                return Ok(user);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet("delete-user")]
        public IActionResult DeleteUserByUid(string uid)
        {
            return HandleException(async () =>
            {
                await _fbService.DeleteUserByUidAsync(uid);
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
