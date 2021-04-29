using Mantasflowers.WebApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;

namespace Mantasflowers.WebApi.Setup.Payment
{
    public static class StripeSetup
    {
        public static void SetupStripe(this IServiceCollection services, IConfiguration configuration)
        {
            var stripeSettings = configuration.GetSection<StripeSettings>("Stripe");
            StripeConfiguration.ApiKey = stripeSettings.SecretKey;
        }
    }
}
