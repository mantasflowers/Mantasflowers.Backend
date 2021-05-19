using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public class UserOrderRepository : BaseRepository<UserOrder>, IUserOrderRepository
    {
        public UserOrderRepository(DatabaseContext dbContext)
            : base(dbContext) { }

        public async override Task<UserOrder> CreateAsync(UserOrder entity)
        {
            _dbContext.Entry(entity.Order).State = EntityState.Unchanged;

            entity.User = await _dbContext.Users.FindAsync(entity.UserId);
            _dbContext.Entry(entity.User).State = EntityState.Unchanged;

            entity = await base.CreateAsync(entity);

            return entity;
        }

        public async Task<IList<UserOrder>> GetUserOrdersByUserId(Guid userId)
        {
            return await _dbContext.UserOrders
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Include(x => x.Order)
                .OrderBy(x => x.Order.CreatedOn)
                .ToListAsync();
        }
    }
}
