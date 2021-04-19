using Autofac;
using Mantasflowers.Services.ServiceAgents;

namespace Mantasflowers.WebApi.Setup.DI
{
    public class ServiceAgentsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FirebaseServiceAgent>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}