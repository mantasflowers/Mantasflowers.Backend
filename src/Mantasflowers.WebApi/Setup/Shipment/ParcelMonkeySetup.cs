using Mantasflowers.Services.ServiceAgents.ParcelMonkey;
using Mantasflowers.WebApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Mantasflowers.WebApi.Setup.Shipment
{
    public static class ParcelMonkeySetup
    {
        public static void SetupParcelMonkey(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticationHeaders = configuration.GetSection<ParcelMonkeyHeaders>("ParcelMonkey");

            services.AddHttpClient("ParcelMonkey", c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("ParcelMonkey")["BaseAddress"]);

                c.DefaultRequestHeaders.Add(authenticationHeaders);
            });
        }
    }
}
