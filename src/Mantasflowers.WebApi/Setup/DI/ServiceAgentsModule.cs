using Autofac;
using Autofac.Extras.DynamicProxy;
using Mantasflowers.Services.ServiceAgents.Firebase;
using Mantasflowers.WebApi.Setup.DI.Interceptors;

namespace Mantasflowers.WebApi.Setup.DI
{
    public class ServiceAgentsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FirebaseServiceAgent>()
                .As<IFirebaseServiceAgent>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}