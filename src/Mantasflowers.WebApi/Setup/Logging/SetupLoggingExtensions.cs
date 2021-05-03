using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Debugging;
using Serilog.Events;

namespace Mantasflowers.WebApi.Setup.Logging
{
    public static class SetupLoggingExtensions
    {
        public static void SetupLogging(this IServiceCollection services)
        {
            var loggerConfiguration = new LoggerConfiguration()
                .Enrich.FromLogContext() // allow dynamic injection of logging properties
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
                .MinimumLevel.Information() // this is the default
                .WriteTo.Console()
                .WriteTo.File("log.txt", rollOnFileSizeLimit: true); // TODO: move this to appsettings when doing global "code -> file" configuration migration (glassbox NFR). Currently no proper way to turn it off/on or configure.

            Log.Logger = loggerConfiguration.CreateLogger();

            // Debugging and Diagnostics (serilog never writes its own events to user defined sinks)
            // This ensures that we see those messages
            // More info: https://github.com/serilog/serilog/wiki/Debugging-and-Diagnostics
            SelfLog.Enable(msg => Debug.WriteLine(msg));
        }
    }
}