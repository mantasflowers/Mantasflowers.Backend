using Mantasflowers.Services.Services.Email;
using Mantasflowers.WebApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid.Extensions.DependencyInjection;

namespace Mantasflowers.WebApi.Setup.Email
{
    public static class SetupSendgridExtensions
    {
        public static void SetupSendgrid(this IServiceCollection services, IConfiguration configuration)
        {
            var stripeSettings = configuration.GetSection<SendgridConfiguration>("Sendgrid");

            services.AddSingleton(stripeSettings);

            services.AddSendGrid(options =>
            {
                options.ApiKey = stripeSettings.ApiKey;
            });
        }
    }
}
