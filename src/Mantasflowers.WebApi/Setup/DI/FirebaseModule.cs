using Autofac;
using Mantasflowers.Services.FirebaseService;

namespace Mantasflowers.WebApi.Setup.DI
{
    public class FirebaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FirebaseService>()
                .SingleInstance();

            builder.RegisterType<FirebaseConfig>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
