using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace Mantasflowers.WebApi.Setup.Newtonsoft
{
    public static class SetupNewtonsoftExtensions
    {
        public static void SetupNewtonsoftDefaults(this IServiceCollection services)
        {
            JsonConvert.DefaultSettings = GenerateDefaultJsonSerializerSettings;
        }

        private static JsonSerializerSettings GenerateDefaultJsonSerializerSettings()
        {
            var settings = new JsonSerializerSettings();

            settings.Converters.Add(new StringEnumConverter { NamingStrategy = new SnakeCaseNamingStrategy() });
            // settings.NullValueHandling = NullValueHandling.Ignore;
            settings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            settings.Formatting = Formatting.Indented;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            return settings;
        }
    }
}