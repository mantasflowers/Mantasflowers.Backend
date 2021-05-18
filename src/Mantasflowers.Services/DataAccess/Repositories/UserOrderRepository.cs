using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public class UserOrderRepository : BaseRepository<UserOrder>, IUserOrderRepository
    {
        public UserOrderRepository(DatabaseContext dbContext)
            : base(dbContext) { }
    }
}
