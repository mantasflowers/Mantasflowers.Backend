using AutoMapper;
using Mantasflowers.Contracts.Order.Response;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.WebApi.Setup.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderAddress, GetOrderAddressResponse>();
            CreateMap<OrderContactInfo, GetOrderContactDetailsResponse>();
            CreateMap<OrderItem, GetOrderItemResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ProductId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Product.Name));

            CreateMap<Order, GetDetailedOrderResponse>()
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.OrderAddress))
                .ForMember(d => d.ContactDetails, opt => opt.MapFrom(s => s.OrderContactInfo));
        }
    }
}
