using Autofac;
using Serilog;
using Serilog.Extensions.Hosting;

namespace Mantasflowers.WebApi.Setup.DI
{
    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => Log.Logger)
                .SingleInstance();

            builder.Register(ctx => new DiagnosticContext(ctx.Resolve<ILogger>()))
                .As<IDiagnosticContext>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}