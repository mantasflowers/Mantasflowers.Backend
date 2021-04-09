using FirebaseAdmin;
using Mantasflowers.Persistence.Authentication;
using Mantasflowers.WebApi.Responses;
using Mantasflowers.WebApi.Setup.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Serilog;
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
            try
            {
                using var client = _clientFactory.CreateClient();

                string content = $"{{\"email\":\"{email}\",\"password\":\"{password}\",\"returnSecureToken\":true}}";

                var response = await client.PostAsync(
                    _requestUri,
                    new StringContent(content, Encoding.UTF8, "application/json")
                    )
                    .ConfigureAwait(false);

                string responseData = await response.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                string tokenId = JObject.Parse(responseData).SelectToken("idToken").ToString();

                return Ok(tokenId);
            }
            catch (FirebaseException ex)
            {
                // TODO
            }

            return Ok(ResponseMsg.NotFound);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet("custom-role")]
        public async Task<IActionResult> SetCustomUserRoleAsync(string uid, string role)
        {
            var claims = new Dictionary<string, object>()
            {
                { ClaimTypes.Role, role },
            };

            await _fbContext.SetCustomUserClaimsAsync(uid, claims);
            return Ok(ResponseMsg.CustomClaimSet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("create-user")]
        public async Task<IActionResult> CreateUserAsync(string email, string password)
        {
            var user = await _fbContext.CreateUserAsync(email, password);
            
            if (user == null)
            {
                return Ok(ResponseMsg.NotFound);
            }

            return Ok(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid">For testing purposes: G46RSuLIvbUjaWJyokcCMDSCeVj1</param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet("get-user/by-uid")]
        public async Task<IActionResult> GetUserByUidAsync(string uid)
        {
            var user = await _fbContext.GetUserByUidAsync(uid);

            if (user == null)
            {
                return Ok(ResponseMsg.NotFound);
            }

            return Ok(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email">For testing purposes: johnny@john.jo</param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet("get-user/by-email")]
        public async Task<IActionResult> GetUserByEmailAsync(string email)
        {
            var user = await _fbContext.GetUserByEmailAsync(email);

            if (user == null)
            {
                return Ok(ResponseMsg.NotFound);
            }

            return Ok(user);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("update-user/email")]
        public async Task<IActionResult> UpdateUserEmailAsync(string uid, string email)
        {
            var user = await _fbContext.UpdateUserEmailAsync(uid, email);

            if (user == null)
            {
                return Ok(ResponseMsg.NotFound);
            }

            return Ok(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("update-user/password")]
        public async Task<IActionResult> UpdateUserPaswordAsync(string uid, string password)
        {
            var user = await _fbContext.UpdateUserPasswordAsync(uid, password);

            if (user == null)
            {
                return Ok(ResponseMsg.NotFound);
            }

            return Ok(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [Authorize(Roles ="admin")]
        [HttpGet("delete-user")]
        public async Task<IActionResult> DeleteUserByUidAsync(string uid)
        {
            await _fbContext.DeleteUserByUidAsync(uid);

            return Ok(ResponseMsg.UserDeleted);
        }
    }
}
