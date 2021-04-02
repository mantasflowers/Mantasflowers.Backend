using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Mantasflowers.WebApi.Setup.Swagger
{
    public static class SwaggerSetup
    {
        public static void SetupSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Mantasflowers API",
                    Version = configuration["Githash"] ?? "GITHASH NOT FOUND",
                });
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }
    }
}