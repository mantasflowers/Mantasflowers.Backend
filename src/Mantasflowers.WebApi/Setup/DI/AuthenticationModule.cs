using Autofac;
using Mantasflowers.Persistence.Authentication;

namespace Mantasflowers.WebApi.Setup.DI
{
    public class AuthenticationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FirebaseContext>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
