using Autofac;
using Mantasflowers.WebApi.Extensions;
using Mantasflowers.WebApi.Setup.Database;
using Mantasflowers.WebApi.Setup.DI;
using Mantasflowers.WebApi.Setup.Logging;
using Mantasflowers.WebApi.Setup.Newtonsoft;
using Mantasflowers.WebApi.Setup.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Serilog;

namespace Mantasflowers.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.SetupLogging();

            services.AddControllers(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter { NamingStrategy = new SnakeCaseNamingStrategy() });
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.SetupNewtonsoftDefaults();

            services.SetupSwagger(Configuration);

            services.SetupDbContext(Configuration);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new LoggingModule());
            builder.RegisterModule(new RepositoriesModule());
            builder.RegisterModule(new ServiceAgentsModule());
            builder.RegisterModule(new ServicesModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.EnsureDatabaseState();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mantasflowers API v1"));

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging(); // TODO: need to figure this out (log not only response, but also request)

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
