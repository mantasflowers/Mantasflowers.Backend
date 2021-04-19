using Mantasflowers.Contracts.Firebase.Response;
using Mantasflowers.Contracts.ServiceAgents.Firebase.Request;
using Mantasflowers.Contracts.ServiceAgents.Firebase.Response;
using Mantasflowers.Services.FirebaseService;
using Mantasflowers.Services.ServiceAgents.Exceptions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mantasflowers.Services.ServiceAgents
{
    public class FirebaseServiceAgent
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly FirebaseConfig _fbConfig;

        public FirebaseServiceAgent(IHttpClientFactory clientFactory, FirebaseConfig fbConfig)
        {
            _clientFactory = clientFactory;
            _fbConfig = fbConfig;
        }

        public async Task<PostSignInResponse> PostSignInAsync(PostSignInRequest request)
        {
            try
            {
                using var client = _clientFactory.CreateClient();
                
                // TODO: can make named configurations of these clients in WebApi instead of configuring using FirebaseConfig object
                // (can avoid having this deadweight singleton flying around)
                var agentResponse = await client.PostAsync<PostSignInResponse>(_fbConfig.SignInUri, request);

                return agentResponse;
            }
            catch (HttpRequestException e)
            {
                throw HandleTokenRelatedError(e);
            }
        }

        public async Task<PostRefreshIdTokenResponse> PostTokenRefreshAsync(PostRefreshIdTokenRequest request)
        {
            try
            {
                using var client = _clientFactory.CreateClient();
                var agentResponse = await client.PostAsync<PostRefreshIdTokenResponse>(_fbConfig.RefreshIdTokenUri, request);

                return agentResponse;
            }
            catch(HttpRequestException e)
            {
                throw HandleTokenRelatedError(e);
            }
        }
        

        private FirebaseTokenException HandleTokenRelatedError(HttpRequestException e)
        {
            var errorData = new { error = new { code = 0, message = "errorid" } };
            errorData = JsonConvert.DeserializeAnonymousType(e.Message ?? string.Empty, errorData);

            var message = errorData?.error?.message ?? FirebaseTokenResponseMsg.NotFound;
            return new FirebaseTokenException(message);
        }
    }
}
