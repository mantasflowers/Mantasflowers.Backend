using Mantasflowers.Persistence;
using Mantasflowers.WebApi.Setup.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Mantasflowers.WebApi.Extensions
{
    public static class ConfigureExtensions
    {
        public static IApplicationBuilder EnsureDatabaseState(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
                var sqlConfig = serviceScope.ServiceProvider.GetRequiredService<SqlConfiguration>();

                dbContext.Database.EnsureCreated();
                
                // TODO: replace any Console.WriteLine's with logger
                if (sqlConfig.DatabaseConfiguration.IsInMemory)
                {
                    System.Console.WriteLine("Using IN MEMORY DB, migrations won't be applied.");
                    return app;
                }

                var migrationNames = dbContext.Database.GetPendingMigrations().ToList();
                if (migrationNames.Count == 0)
                {
                    System.Console.WriteLine("No DB migrations to apply.");
                }
                else
                {
                    System.Console.WriteLine($"There are {migrationNames.Count} DB migrations that will be applied");
                    System.Console.WriteLine("Applying DB migrations...");

                    dbContext.Database.SetCommandTimeout(120); // arbitrary number, subject for change
                    dbContext.Database.Migrate();
                }
            }

            return app;
        }
    } 
}