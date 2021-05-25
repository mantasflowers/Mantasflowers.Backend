using AutoMapper;
using Mantasflowers.Contracts.Common;
using Mantasflowers.Contracts.Email.Request;
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
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Product.Name))
                .ForMember(d => d.ThumbnailPictureUrl, opt => opt.MapFrom(s => s.Product.ThumbnailPictureUrl));

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

            CreateMap<Order, GetOrderResponse>();
            CreateMap<PagedModel<Order>, GetOrdersResponse>();

            CreateMap<UpdateOrderStatusRequest, Order>()
                .ForMember(d => d.RowVersion, opt => opt.Ignore());

            CreateMap<Order, SendEmailRequest>()
                .ForMember(d => d.ClientEmail, opt => opt.MapFrom(s => s.OrderContactInfo.Email))
                .ForMember(d => d.OrderNumber, opt => opt.MapFrom(s => s.OrderNumber))
                .ForMember(d => d.OrderPassword, opt => opt.MapFrom(s => s.UniquePassword));
        }
    }
}
