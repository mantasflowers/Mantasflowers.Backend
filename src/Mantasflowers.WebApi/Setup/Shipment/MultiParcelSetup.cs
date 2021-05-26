using Mantasflowers.Services.ServiceAgents.MultiParcels;
using Mantasflowers.WebApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;

namespace Mantasflowers.WebApi.Setup.Shipment
{
    public static class MultiParcelSetup
    {
        public static void SetupMultiParcel(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticationHeaders = configuration.GetSection<MultiParcelHeaders>("MultiParcel");

            services.AddHttpClient("MultiParcel", c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("MultiParcel")["BaseAddress"]);

                c.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", authenticationHeaders.Bearer);
            });
        }
    }
}
