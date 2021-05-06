using AutoMapper;
using Mantasflowers.Contracts.Order.Request;
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

            CreateMap<PostOrderAddressRequest, OrderAddress>();
            CreateMap<PostOrderContactDetailsRequest, OrderContactInfo>();
            CreateMap<Order, GetDetailedOrderResponse>()
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.OrderAddress))
                .ForMember(d => d.ContactDetails, opt => opt.MapFrom(s => s.OrderContactInfo));

            CreateMap<PostOrderItemRequest, OrderItem>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.Id));
            CreateMap<PostCreateOrderRequest, Order>()
                .ForMember(d => d.OrderAddress, opt => opt.MapFrom(s => s.Address))
                .ForMember(d => d.OrderContactInfo, opt => opt.MapFrom(s => s.ContactDetails));
        }
    }
}
