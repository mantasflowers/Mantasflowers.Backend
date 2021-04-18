using AutoMapper;
using Mantasflowers.Contracts.Common;
using Mantasflowers.Contracts.Product.Response;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.WebApi.Setup.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductResponse>();
            CreateMap<PagedModel<Product>, GetProductsResponse>();

            CreateMap<Product, GetDetailedProductResponse>()
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.ProductInfo.Description))
                .ForMember(d => d.PictureUrl, opt => opt.MapFrom(s => s.ProductInfo.PictureUrl));
        }
    }
}