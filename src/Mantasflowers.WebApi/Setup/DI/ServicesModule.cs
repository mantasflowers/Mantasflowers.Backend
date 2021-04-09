using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Mantasflowers.Services.Services.Product;

namespace Mantasflowers.WebApi.Setup.DI
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAutoMapper(typeof(Startup).Assembly);

            builder.RegisterType<ProductService>()
                .As<IProductService>()
                .InstancePerDependency();

            base.Load(builder);
        }
    }
}