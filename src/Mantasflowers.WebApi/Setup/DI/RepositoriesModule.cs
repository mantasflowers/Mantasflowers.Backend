using Autofac;
using Autofac.Extras.DynamicProxy;
using Mantasflowers.Services.DataAccess.Repositories;
using Mantasflowers.WebApi.Setup.DI.Interceptors;

namespace Mantasflowers.WebApi.Setup.DI
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductReviewRepository>()
                .As<IProductReviewRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}