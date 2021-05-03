using Autofac;
using Mantasflowers.Services.Repositories;

namespace Mantasflowers.WebApi.Setup.DI
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerDependency();

            builder.RegisterType<ProductReviewRepository>()
                .As<IProductReviewRepository>()
                .InstancePerDependency();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
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