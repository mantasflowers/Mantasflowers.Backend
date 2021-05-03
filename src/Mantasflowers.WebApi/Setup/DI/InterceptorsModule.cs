using Autofac;
using Mantasflowers.WebApi.Setup.DI.Interceptors;

namespace Mantasflowers.WebApi.Setup.DI
{
    public class InterceptorsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(AsyncInterceptorAdapter<>));

            builder.RegisterType<MethodCallInterceptorAsync>();

            base.Load(builder);
        }
    }
}