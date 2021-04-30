using Mantasflowers.Contracts.Order.Request;
using Mantasflowers.Contracts.Order.Response;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Order
{
    public interface IOrderService
    {
        Task<GetDetailedOrderResponse> GetDetailedOrderInfoAsync(Guid id);

        // Consider having separate internal interface
        Task<Domain.Entities.Order> CreateOrderAsync(PostCreateOrderRequest request);

        Task<IDbContextTransaction> BeginTransactionAsync();

        IExecutionStrategy CreateExecutionStrategy();
    }
}
