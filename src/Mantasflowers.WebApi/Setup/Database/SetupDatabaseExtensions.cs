using Microsoft.Extensions.Configuration;

namespace Mantasflowers.WebApi.Setup.Database
{
    public static class SetupDatabaseExtensions
    {
        public static T GetSection<T>(this IConfiguration configuration, string sectionName)
            where T: new()
        {
            T obj = new T();
            configuration.GetSection(sectionName).Bind(obj);
            return obj;
        }
    }
}