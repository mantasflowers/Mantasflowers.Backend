using Autofac;
using Autofac.Extras.DynamicProxy;
using Mantasflowers.Services.Repositories;
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
                .InstancePerDependency();

            builder.RegisterType<ProductReviewRepository>()
                .As<IProductReviewRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerDependency();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerDependency();

            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>()
                .InstancePerDependency();

            builder.RegisterType<CouponRepository>()
                .As<ICouponRepository>()
                .InstancePerDependency();

            base.Load(builder);
        }
    }
}