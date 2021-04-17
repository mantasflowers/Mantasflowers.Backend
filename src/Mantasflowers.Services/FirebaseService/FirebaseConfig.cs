using Microsoft.Extensions.Options;

namespace Mantasflowers.Services.FirebaseService
{
    public sealed class FirebaseConfig
    {
        public readonly string SignInUri;

        public readonly string RefreshIdTokenUri;

        public FirebaseConfig(IOptions<WebApiKey> optionsAccessor)
        {
            SignInUri = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={optionsAccessor.Value.Value}";
            RefreshIdTokenUri = $"https://securetoken.googleapis.com/v1/token?key={optionsAccessor.Value.Value}";
        }
    }
}
