using Autofac;
using Mantasflowers.Services.Services.Product;
using Mantasflowers.Services.Services.Review;
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
                .InstancePerDependency();

            builder.RegisterType<ProductReviewService>()
                .As<IProductReviewService>()
                .InstancePerDependency();

            base.Load(builder);
        }
    }
}