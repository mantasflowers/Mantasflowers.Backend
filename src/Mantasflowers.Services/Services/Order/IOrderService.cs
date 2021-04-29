using Mantasflowers.Contracts.Order.Response;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Order
{
    public interface IOrderService
    {
        Task<GetDetailedOrderResponse> GetDetailedOrderInfoAsync(Guid id);
    }
}
