using Mantasflowers.Contracts.Errors;
using Mantasflowers.Contracts.User.Request;
using Mantasflowers.Contracts.User.Response;
using Mantasflowers.Services.Services.Exceptions;
using Mantasflowers.Services.Services.User;
using Mantasflowers.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mantasflowers.WebApi.Controllers
{
    [Authorize]
    [Route("/user")]
    [ApiController]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser()
        {
            string uid = User.GetUid();
            var response = await _userService.GetUserByUidAsync(uid);
            
            Response.Headers.AddETagHeader(response.RowVersion);

            return Ok(response);
        }

        [HttpGet("detailed")]
        [ProducesResponseType(typeof(GetDetailedUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetailedUser()
        {
            string uid = User.GetUid();
            var emailData = User.GetEmailInfo();

            var response = await _userService.GetDetailedUserByUidAsync(uid, emailData.Email, emailData.IsEmailVerified);

            Response.Headers.AddETagHeader(response.RowVersion);

            return Ok(response);
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser()
        {
            string uid = User.GetUid();

            await _userService.DeleteUserAsync(uid);

            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(typeof(PostCreateUserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateUser(PostCreateUserRequest postCreateUserRequest)
        {
            var response = 
                await _userService.CreateUserAsync(postCreateUserRequest.Email, postCreateUserRequest.Password);

            return StatusCode(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// For updating login email/password, look at 'Authentication'.
        /// </summary>
        [HttpPatch("update")]
        [ProducesResponseType(typeof(UpdateUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest request,
            [FromHeader] byte[] etag)
        {
            string uid = User.GetUid();

            request.RowVersion = etag;

            try
            {
                var response = await _userService.UpdateUserAsync(uid, request);
                return Ok(response);
            }
            catch (ConcurrentEntityUpdateException e)
            {
                return Conflict(e.Message);
            }
        }
    }
}
