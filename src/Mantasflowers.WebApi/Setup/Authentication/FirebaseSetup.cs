using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mantasflowers.WebApi.Setup.Authentication
{
    public static class FirebaseSetup
    {
        public static void SetupFirebase(this IServiceCollection services, IConfiguration configuration)
        {
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromJson(configuration["FirebaseConfig"])
                });
            }
        }
    }
}
