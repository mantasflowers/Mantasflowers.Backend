using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.Firebase.Response
{
    public class PostRefreshIdTokenResponse
    {
        [JsonProperty("access_token")]
        public string IdToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
