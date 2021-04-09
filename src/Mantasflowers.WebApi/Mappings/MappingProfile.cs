using AutoMapper;
using Mantasflowers.Contracts.Common;
using Mantasflowers.Contracts.Product.Response;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // TODO: look this up a bit (documentation + elsewhere)
            CreateMap<Product, GetProductResponse>();
            CreateMap<PagedModel<Product>, GetProductsResponse>();
        }
    }
}