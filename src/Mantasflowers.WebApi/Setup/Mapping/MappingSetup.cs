using Autofac;
using AutoMapper;
using Mantasflowers.Contracts.Common;
using Mantasflowers.Contracts.Product.Response;
using Mantasflowers.Contracts.Review.Response;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.WebApi.Setup.Mapping
{
    public static class MappingSetup
    {
        public static void SetupMapping(this ContainerBuilder containerBuilder)
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Product, GetProductResponse>();
                x.CreateMap<PagedModel<Product>, GetProductsResponse>();

                x.CreateMap<Product, GetDetailedProductResponse>()
                    .ForMember(d => d.Description, opt => opt.MapFrom(s => s.ProductInfo.Description))
                    .ForMember(d => d.PictureUrl, opt => opt.MapFrom(s => s.ProductInfo.PictureUrl));

                x.CreateMap<ProductReview, GetProductReviewsResponse>()
                    .ForMember(d => d.UserFirstName, opt => opt.MapFrom(s => s.User.FirstName))
                    .ForMember(d => d.Date, opt => opt.MapFrom(s => s.UpdatedOn));
            });

            var mapper = config.CreateMapper();

            containerBuilder.RegisterInstance(mapper)
                .As<IMapper>()
                .SingleInstance();
        }
    }
}