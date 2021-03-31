using Mantasflowers.Persistence;
using Mantasflowers.WebApi.Setup.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Linq;

namespace Mantasflowers.WebApi.Extensions
{
    public static class ConfigureExtensions
    {
        public static void EnsureDatabaseState(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
                var sqlConfig = serviceScope.ServiceProvider.GetRequiredService<SqlConfiguration>();
                var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger>();

                if (sqlConfig.DatabaseConfiguration.IsInMemory)
                {
                    logger.Information("Using IN MEMORY DB, migrations won't be applied.");
                    return;
                }

                var migrationNames = dbContext.Database.GetPendingMigrations().ToList();
                if (migrationNames.Count == 0)
                {
                    logger.Information("No DB migrations to apply.");
                }
                else
                {
                    logger.Information($"There are {migrationNames.Count} DB migrations that will be applied");
                    logger.Information("Applying DB migrations...");

                    dbContext.Database.SetCommandTimeout(120); // arbitrary number, subject for change
                    dbContext.Database.Migrate();
                }
            }
        }
    } 
}