using Mantasflowers.Contracts.Order.Request;
using Mantasflowers.Contracts.Order.Response;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Order
{
    public interface IOrderService
    {
        Task<Domain.Entities.Order> GetDetailedOrderAsync(Guid id);

        Task<GetDetailedOrderResponse> GetDetailedOrderInfoAsync(Guid id);

        Task<GetDetailedOrderResponse> GetDetailedOrderInfoAsync(string uniquePassword);

        Task<Domain.Entities.Order> CreateOrderAsync(PostCreateOrderRequest request);

        Task<Domain.Entities.UserOrder> LinkUserToOrderAsync(Guid userId, Domain.Entities.Order order);

        Task<GetOrdersResponse> GetPaginatedOrdersAsync(GetOrdersRequest request);

        Task<GetUserOrdersResponse> GetUserOrdersAsync(Guid userId);

        Task<GetDetailedOrderResponse> UpdateOrderStatusAsync(Guid id, UpdateOrderStatusRequest request);
    }
}
