using Mantasflowers.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mantasflowers.WebApi.Setup.Database
{
    public static class DatabaseSetup
    {
        public static IServiceCollection SetupDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            var databaseConfiguration = configuration.GetSection<DatabaseConfiguration>("Database");
            var secret = configuration.GetSection<Secret>("Sql");
            var sqlConfig = new SqlConfiguration(connectionString, databaseConfiguration, secret);

            if (sqlConfig.DatabaseConfiguration.IsInMemory)
            {
                services.AddDbContext<DatabaseContext>(options =>
                {
                    options.UseInMemoryDatabase("IN_MEMORY")
                        .ConfigureWarnings(x =>
                            x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                        .ConfigureWarnings(x => 
                            x.Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning));
                });
                // TODO: test if lifetime scopes don't need to be changed for in memory db (maybe singleton?)
            }
            else
            {
                services.AddDbContext<DatabaseContext>(options =>
                {
                    options.UseSqlServer(sqlConfig.ConnectionString, x => x.EnableRetryOnFailure())
                        .ConfigureWarnings(x =>
                            x.Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning));
                });
                // TODO: are Scoped lifetimes ok?
            }

            return services;
        }
    }
}