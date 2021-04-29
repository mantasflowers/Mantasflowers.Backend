using Microsoft.Extensions.Configuration;

namespace Mantasflowers.WebApi.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T GetSection<T>(this IConfiguration configuration, string sectionName)
            where T : new()
        {
            T obj = new();
            configuration.GetSection(sectionName).Bind(obj);
            return obj;
        }
    }
}
