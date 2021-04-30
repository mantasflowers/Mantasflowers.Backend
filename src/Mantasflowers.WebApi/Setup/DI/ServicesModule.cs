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
                .InstancePerLifetimeScope();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();

            // TODO: add interface for this so that interface level interception can be done
            builder.RegisterType<FirebaseService>()
                .InstancePerDependency();

            // TODO: get rid of this (read MSDN docs on httpClients configuration)
            builder.RegisterType<FirebaseConfig>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}