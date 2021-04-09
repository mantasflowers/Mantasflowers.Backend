using Autofac;
using AutoMapper;
using Mantasflowers.Contracts.Common;
using Mantasflowers.Contracts.Product.Response;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.WebApi.Setup.Mapping
{
    public static class MappingSetup
    {
        public static void SetupMapping(this ContainerBuilder containerBuilder)
        {
            var config = new MapperConfiguration(x =>
            {
                // TODO: look this up a bit (documentation + elsewhere)
                x.CreateMap<Product, GetProductResponse>();
                x.CreateMap<PagedModel<Product>, GetProductsResponse>();
            });

            var mapper = config.CreateMapper();

            containerBuilder.RegisterInstance(mapper)
                .As<IMapper>()
                .SingleInstance();
        }
    }
}