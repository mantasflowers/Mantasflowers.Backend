using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.Firebase.Request
{
    public class PostRefreshIdTokenRequest
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; set; } = "refresh_token";

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
