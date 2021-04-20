using Newtonsoft.Json;

namespace Mantasflowers.Contracts.Firebase.Response
{
    public class PostTokensResponse
    {
        [JsonProperty("idToken")]
        public string IdToken { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
