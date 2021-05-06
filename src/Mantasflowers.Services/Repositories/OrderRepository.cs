using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DatabaseContext dbContext)
            : base(dbContext) {}

        public async Task<Order> GetDetailedOrderAsync(Guid id)
        {
            var order = await _dbContext.Orders
                .Include(x => x.OrderAddress)
                .Include(x => x.OrderContactInfo)
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                // .Include(x => x.Payment)
                // .Include(x => x.Shipment)
                .SingleOrDefaultAsync(x => x.Id == id);

            return order;
        }
    }
}
