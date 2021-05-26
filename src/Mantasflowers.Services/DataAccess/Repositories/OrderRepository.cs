using Mantasflowers.Contracts.Common;
using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;
using Mantasflowers.Services.DataShaping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DatabaseContext dbContext)
            : base(dbContext) { }

        public async Task<Order> GetDetailedOrderAsync(Guid id)
        {
            var order = await GetDetailedOrderAsync(x => x.Id == id);

            return order;
        }

        public async Task<Order> GetDetailedOrderAsync(string paymentIntentId)
        {
            var order = await GetDetailedOrderAsync(x => x.Payment.PaymentIntentId == paymentIntentId);

            return order;
        }

        private async Task<Order> GetDetailedOrderAsync(Expression<Func<Order, bool>> predicate)
        {
            var order = await _dbContext.Orders
                .Include(x => x.OrderAddress)
                .Include(x => x.OrderContactInfo)
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .Include(x => x.Payment)
                .Include(x => x.Shipment)
                .SingleOrDefaultAsync(predicate);

            return order;
        }

        public async override Task<Order> CreateAsync(Order entity)
        {
            foreach (var item in entity.OrderItems)
            {
                item.Product = await _dbContext.Products.FindAsync(item.ProductId);
                _dbContext.Entry(item.Product).State = EntityState.Unchanged;
            }

            entity = await base.CreateAsync(entity);

            return entity;
        }

        public async Task<PagedModel<Order>> GetPaginatedFilteredOrderedListAsync(int page, int limit,
            Expression<Func<Order, bool>> filter, string orderByPropertyName, bool orderDescending)
        {
            var orders = await _dbContext.Orders
                .AsNoTracking()
                .Where(filter)
                .OrderByPropertyName(orderByPropertyName, orderDescending)
                .PaginateAsync(page, limit);

            return orders;
        }

        public void UpdateOriginalInternalRowVersion(Order order, byte[] rowVersion)
        {
            _dbContext.Entry(order).OriginalValues[nameof(order.RowVersion)] = rowVersion;
        }
    }
}
