using FirebaseAdmin.Auth;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using Mantasflowers.Contracts.Firebase;

namespace Mantasflowers.Services.FirebaseService
{
    public sealed class FirebaseService
    {
        private readonly IHttpClientFactory _clientFactory;

        private readonly FirebaseConfig _fbConfig;

        public FirebaseService(IHttpClientFactory clientFactory, FirebaseConfig firebaseConfig)
        {
            _clientFactory = clientFactory;
            _fbConfig = firebaseConfig;
        }

        public async Task<GetTokensResponse> GetTokensAsync(string email, string password)
        {
            string responseData = string.Empty;
            try
            {
                using var client = _clientFactory.CreateClient();
                string content = JsonConvert.SerializeObject(new { email = email, password = password, returnSecureToken = true });

                var response = await client.PostAsync(
                    _fbConfig.SignInUri,
                    new StringContent(content, Encoding.UTF8, "application/json")
                    );

                responseData = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<GetTokensResponse>(responseData);
            }
            catch (HttpRequestException)
            {
                throw new HttpRequestException(responseData);
            }
        }

        public async Task<GetTokensResponse> RefreshIdTokenAsync(string refreshToken)
        {
            string responseData = string.Empty;
            try
            {
                using var client = _clientFactory.CreateClient();
                string content = JsonConvert.SerializeObject(new { grant_type = "refresh_token", refresh_token = refreshToken });

                var response = await client.PostAsync(
                    _fbConfig.RefreshIdTokenUri,
                    new StringContent(content, Encoding.UTF8, "application/json")
                    );

                responseData = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<GetTokensResponse>(responseData);
            }
            catch (HttpRequestException)
            {
                throw new HttpRequestException(responseData);
            }
        }

        public Task SetCustomUserClaimsAsync(string uid, Dictionary<string, object> claims)
        {
            return FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(uid, claims);
        }

        /// <summary>
        /// Only meant to verify ID tokens that come from the client SDKs, not the custom tokens
        /// </summary>
        /// <param name="idToken"></param>
        /// <returns></returns>
        public Task<FirebaseToken> VerifyIdTokenAsync(string idToken)
        {
            return FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
        }

        public Task<UserRecord> CreateUserAsync(string email, string password)
        {
            var args = new UserRecordArgs()
            {
                Email = email,
                EmailVerified = false,
                Password = password,
                Disabled = false
            };

            return FirebaseAuth.DefaultInstance.CreateUserAsync(args);
        }

        public Task<UserRecord> GetUserByUidAsync(string uid)
        {
            return FirebaseAuth.DefaultInstance.GetUserAsync(uid);
        }

        public Task<UserRecord> GetUserByEmailAsync(string email)
        {
            return FirebaseAuth.DefaultInstance.GetUserByEmailAsync(email);
        }

        private Task<UserRecord> UpdateUserAsync(UserRecordArgs args)
        {
            return FirebaseAuth.DefaultInstance.UpdateUserAsync(args);
        }

        public Task<UserRecord> UpdateUserEmailAsync(string uid, string email)
        {
            return UpdateUserAsync(new UserRecordArgs
            {
                Uid = uid,
                Email = email
            });
        }

        public Task<UserRecord> UpdateUserPasswordAsync(string uid, string password)
        {
            return UpdateUserAsync(new UserRecordArgs
            {
                Uid = uid,
                Password = password
            });
        }

        public Task DeleteUserByUidAsync(string uid)
        {
            return FirebaseAuth.DefaultInstance.DeleteUserAsync(uid);
        }

        public Task RevokeRefreshTokensAsync(string uid)
        {
            return FirebaseAuth.DefaultInstance.RevokeRefreshTokensAsync(uid);
        }
    }
}
