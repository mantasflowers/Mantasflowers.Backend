using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.Firebase.Request
{
    public class PostSignInRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("returnSecureToken")]
        public bool ReturnSecureToken { get; set; } = true;
    }
}
