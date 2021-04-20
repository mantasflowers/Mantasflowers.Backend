using Mantasflowers.Contracts.Errors;
using Mantasflowers.Contracts.Firebase.Request;
using Mantasflowers.Contracts.Firebase.Response;
using Mantasflowers.Contracts.User.Response;
using Mantasflowers.Services.FirebaseService;
using Mantasflowers.Services.ServiceAgents.Exceptions;
using Mantasflowers.Services.Services.User;
using Mantasflowers.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mantasflowers.WebApi.Controllers
{
    [ApiController]
    [Route("/authentication")]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public class AuthenticationController : ControllerBase
    {
        private readonly FirebaseService _fbService;
        private readonly IUserService _userService;

        public AuthenticationController(FirebaseService fbService, IUserService userService)
        {
            _fbService = fbService;
            _userService = userService;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(PostTokensResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginAsync([FromBody] PostCredentialsRequest request)
        {
            try
            {
                var response = await _fbService.GetTokensAsync(request);
                return Ok(response);
            }
            catch (FirebaseTokenException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPost("refresh-token")]
        [ProducesResponseType(typeof(PostTokensResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] PostRefreshTokenRequest request)
        {
            try
            {
                var response = await _fbService.RefreshIdTokenAsync(request);
                return Ok(response);
            }
            catch (FirebaseTokenException e)
            {
                return Unauthorized(e.Message);
            }
        }

        /// <summary>
        /// Invalidates refresh token. The actual token is still valid. It is the clients responsibility to remove any browser stored tokens.
        /// </summary>
        [Authorize]
        [HttpPost("logout")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> RevokeRefreshToken()
        {
            string uid = User.GetUidFromJwt();
            await _fbService.RevokeRefreshTokenAsync(uid);

            return Ok(FirebaseTokenResponseMsg.RefreshTokenRevoked);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("admin/change-role")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangeRole([FromBody] PostRoleRequest request)
        {
            var claims = new Dictionary<string, object>()
            {
                { ClaimTypes.Role, request.Role.ToLower() },
            };

            var userUid = await _userService.GetUserUidByGuidAsync(request.UserId);
            if (userUid == null)
            {
                return NotFound("User not found");
            }

            await _fbService.SetCustomUserClaimsAsync(userUid, claims);
            
            return Ok(FirebaseTokenResponseMsg.CustomClaimSet);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("admin/user-by-id")]
        [ProducesResponseType(typeof(GetDetailedUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByGuid(Guid id)
        {
            var response = await _userService.GetDetailedUserByGuidAsync(id);
            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("admin/user-by-email")]
        [ProducesResponseType(typeof(GetDetailedUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var firebaseUser = await _fbService.GetUserByEmailAsync(email);
            var response = await _userService.GetDetailedUserByUidAsync(firebaseUser.Uid,
                firebaseUser.Email, firebaseUser.EmailVerified);
            
            return Ok(response);
        }

        [Authorize]
        [HttpPost("update/email")]
        [ProducesResponseType(typeof(UpdateEmailResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUserEmail(PostUpdateEmailRequest request)
        {
            string uid = User.GetUidFromJwt();

            var user = await _fbService.UpdateUserEmailAsync(uid, request.Email);
            var resposne = new UpdateEmailResponse()
            {
                Email = user.Email
            };
            
            return Ok(resposne);
        }

        [Authorize]
        [HttpPost("update/password")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateUserPassword(PostUpdatePasswordRequest request)
        {
            var uid = User.GetUidFromJwt();

            await _fbService.UpdateUserPasswordAsync(uid, request.Password);

            return NoContent();
        }
    }
}
