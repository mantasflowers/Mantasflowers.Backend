using Autofac;
using FluentValidation.AspNetCore;
using Mantasflowers.Services.FirebaseService;
using Mantasflowers.WebApi.Extensions;
using Mantasflowers.WebApi.Middleware;
using Mantasflowers.WebApi.Setup.Database;
using Mantasflowers.WebApi.Setup.DI;
using Mantasflowers.WebApi.Setup.Logging;
using Mantasflowers.WebApi.Setup.Newtonsoft;
using Mantasflowers.WebApi.Setup.Swagger;
using Mantasflowers.WebApi.Validation;
using Mantasflowers.WebApi.Setup.Payment;
using Mantasflowers.WebApi.Setup.UserManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Mantasflowers.WebApi.Setup.DI.CustomAutofac;
using Mantasflowers.WebApi.Setup.Email;

namespace Mantasflowers.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        private static readonly string _corsPolicyName = "CORSPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                {
                    options.Authority = "https://securetoken.google.com/" + Configuration["ProjectId"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/" + Configuration["ProjectId"],
                        ValidateAudience = true,
                        ValidAudience = Configuration["ProjectId"],
                        ValidateLifetime = true,
                    };
                });

            services.Configure<WebApiKey>(o => o.Value = Configuration["WebApiKey"]);

            services.AddHttpClient();

            services.ConfigureCORS(Environment, _corsPolicyName);

            services.SetupLogging(Configuration);

            services.AddControllers(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
                options.Filters.Add(new ConsumesAttribute("application/json"));
                options.Filters.Add(typeof(ValidateRequestAttribute));
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter { NamingStrategy = new SnakeCaseNamingStrategy() });
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            })
            .AddFluentValidation(o =>
            {
                o.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                // This is replaced with a global ValidateRequestAttribute
                options.SuppressModelStateInvalidFilter = true;
            });

            services.SetupNewtonsoftDefaults();

            services.SetupSwagger(Configuration);

            services.SetupDbContext(Configuration);

            services.SetupFirebase(Configuration);

            services.SetupStripe(Configuration);

            services.SetupSendgrid(Configuration);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new LoggingModule());
            builder.RegisterModule(new RepositoriesModule());
            builder.RegisterModule(new ServiceAgentsModule());
            builder.RegisterModule(new ServicesModule());
            // builder.RegisterModule(new InterceptorsModule());

            builder.LoadCustomAutofacJson(Configuration["CustomAutofacConfig:ConfigFilePath"]);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.EnsureDatabaseState();

            app.UseSerilogRequestResponseLogging();

            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mantasflowers API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_corsPolicyName);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<LogContextInjectionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
