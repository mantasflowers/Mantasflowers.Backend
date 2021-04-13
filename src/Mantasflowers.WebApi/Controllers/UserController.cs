using FirebaseAdmin.Auth;
using Mantasflowers.Persistence.Authentication;
using Mantasflowers.WebApi.Extensions;
using Mantasflowers.WebApi.Responses;
using Mantasflowers.WebApi.Setup.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mantasflowers.WebApi.Controllers
{
    [ApiController]
    [Route("/firebase")]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger = Log.ForContext<UserController>();

        private readonly FirebaseContext _fbContext;

        private readonly IHttpClientFactory _clientFactory;

        private readonly string _requestUri;

        public UserController(FirebaseContext fbContext, IHttpClientFactory clientFactory, IOptionsMonitor<WebApiKey> optionsAccessor)
        {
            _fbContext = fbContext;
            _clientFactory = clientFactory;
            _requestUri = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={optionsAccessor.CurrentValue.Value}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("get-token")]
        public async Task<IActionResult> GetTokenAsync(string email, string password)
        {
            string responseData = string.Empty;
            try
            {
                using var client = _clientFactory.CreateClient();

                string content = $"{{\"email\":\"{email}\",\"password\":\"{password}\",\"returnSecureToken\":true}}";

                var response = await client.PostAsync(
                    _requestUri,
                    new StringContent(content, Encoding.UTF8, "application/json")
                    )
                    .ConfigureAwait(false);

                responseData = await response.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                string tokenId = JObject.Parse(responseData).SelectToken("idToken").ToString();

                return Ok(tokenId);
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
                await _fbContext.SetCustomUserClaimsAsync(uid, claims);
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
                var user = await _fbContext.CreateUserAsync(email, password);
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
                var user = await _fbContext.GetUserByUidAsync(uid);
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
                var user = await _fbContext.GetUserByEmailAsync(email);
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
                var user = await _fbContext.UpdateUserEmailAsync(uid, email);
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
                var user = await _fbContext.UpdateUserPasswordAsync(uid, password);
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
                await _fbContext.DeleteUserByUidAsync(uid);
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
