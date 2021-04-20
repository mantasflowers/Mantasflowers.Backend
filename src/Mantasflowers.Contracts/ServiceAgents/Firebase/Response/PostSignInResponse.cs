using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.Firebase.Response
{
    public class PostSignInResponse
    {
        [JsonProperty("idToken")]
        public string IdToken { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
