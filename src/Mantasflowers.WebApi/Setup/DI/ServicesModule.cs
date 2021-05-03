using Autofac;
using Autofac.Extras.DynamicProxy;
using Mantasflowers.Services.FirebaseService;
using Mantasflowers.Services.Services.Product;
using Mantasflowers.Services.Services.Review;
using Mantasflowers.Services.Services.User;
using Mantasflowers.WebApi.Setup.DI.Interceptors;
using Mantasflowers.WebApi.Setup.Mapping;

namespace Mantasflowers.WebApi.Setup.DI
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.SetupMapping();

            builder.RegisterType<ProductService>()
                .As<IProductService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductReviewService>()
                .As<IProductReviewService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerLifetimeScope();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerLifetimeScope();

            // TODO: this doesn't have an interface and can't be logged using interface interception.
            //     Class interception would require changes to the FirebaseService itself and as such:
            //     1. We either add a useless interface to this (just for interception)
            //     2. We don't log this with hopes that noone sees it or we can justify not logging this :)
            builder.RegisterType<FirebaseService>()
                .InstancePerDependency();

            // TODO: get rid of this (read MSDN docs on httpClients configuration)
            builder.RegisterType<FirebaseConfig>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}