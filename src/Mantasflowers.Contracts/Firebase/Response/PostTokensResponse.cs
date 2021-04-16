using Newtonsoft.Json;

namespace Mantasflowers.Contracts.Firebase.Response
{
    public class PostTokensResponse
    {
        [JsonProperty("idToken")]
        public string IdToken { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Firebase's different endpoints return 
        /// differently formatted attributes for same values.
        /// </summary>
        [JsonProperty("id_token")]
        private string id_Token { set => IdToken = value; }

        [JsonProperty("refresh_token")]
        private string refresh_token { set => RefreshToken = value; }
    }
}
