using FirebaseAdmin.Auth;
using Mantasflowers.Contracts.Errors;
using Mantasflowers.Contracts.User.Request;
using Mantasflowers.Contracts.User.Response;
using Mantasflowers.Services.FirebaseService;
using Mantasflowers.Services.Services.Exceptions;
using Mantasflowers.Services.Services.User;
using Mantasflowers.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly FirebaseService _fbService;

        public UserController(IUserService userService, FirebaseService fbService)
        {
            _userService = userService;
            _fbService = fbService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser()
        {
            string uid = User.GetUid();
            var response = await _userService.GetUserByUidAsync(uid);

            return Ok(response);
        }

        [HttpGet("detailed")]
        [ProducesResponseType(typeof(GetDetailedUserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDetailedUser()
        {
            string uid = User.GetUid();
            var emailData = User.GetEmailInfo();

            var response = await _userService.GetDetailedUserByUidAsync(uid, emailData.Email, emailData.IsEmailVerified);

            return Ok(response);
        }

        /// <summary>
        /// [NOT IMPLEMENTED] Completely delete user and all its information.
        /// </summary>
        [HttpPost("delete")]
        public IActionResult DeleteUser()
        {
            // TODO: this needs to delete user and any data related to it in our DB + firebaseUser
            throw new NotImplementedException("NOT IMPLEMENTED");
        }

        // TODO: transactions?
        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(typeof(PostCreateUserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateUser(PostCreateUserRequest postCreateUserRequest)
        {
            UserRecord firebaseUser = null;
            firebaseUser = await _fbService.CreateUserAsync(postCreateUserRequest.Email, postCreateUserRequest.Password);

            if (string.IsNullOrWhiteSpace(firebaseUser.Uid))
            {
                throw new FirebaseUidNotFoundException("Firebase did not return Uid after creating user");
            }

            var response = await _userService.CreateUserAsync(firebaseUser.Uid);

            response.LoginEmail = firebaseUser.Email;

            return StatusCode(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// [NOT IMPLEMENTED]
        /// </summary>
        [HttpPut("update")]
        public IActionResult UpdateUser()
        {
            throw new NotImplementedException("NOT IMPLEMENTED");
        }
    }
}
