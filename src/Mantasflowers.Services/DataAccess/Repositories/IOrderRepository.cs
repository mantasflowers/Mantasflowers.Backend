using Mantasflowers.Contracts.Common;
using Mantasflowers.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetDetailedOrderAsync(Guid id);

        Task<PagedModel<Order>> GetPaginatedFilteredOrderedListAsync(int page, int limit,
            Expression<Func<Order, bool>> filter, string orderByPropertyName, bool orderDescending);
    }
}
