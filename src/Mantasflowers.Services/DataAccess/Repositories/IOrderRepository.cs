using Mantasflowers.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetDetailedOrderAsync(Guid id);
    }
}
