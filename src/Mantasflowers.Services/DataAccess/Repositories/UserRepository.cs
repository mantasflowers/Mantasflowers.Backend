using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext dbContext)
            : base(dbContext) {}

        public async Task<User> GetUserByUidAsync(string uid)
        {
            var user = await _dbContext.Users
                .SingleOrDefaultAsync(x => x.Uid == uid);

            return user;
        }

        public void UpdateOriginalInternalRowVersion(User user, byte[] rowVersion)
        {
            _dbContext.Entry(user).OriginalValues[nameof(user.RowVersion)] = rowVersion;
        }

        public async Task<User> GetDetailedUserByUidAsync(string uid)
        {
            var user = await _dbContext.Users
                .Include(x => x.UserContactInfo)
                .Include(x => x.Address)
                .SingleOrDefaultAsync(x => x.Uid == uid);

            return user;
        }

        public async Task<User> GetDetailedUserByIdAsync(Guid id)
        {
            var user = await _dbContext.Users
                .Include(x => x.UserContactInfo)
                .Include(x => x.Address)
                .SingleOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<User> GetUserGraphByUidAsync(string uid)
        {
            var user = await _dbContext.Users
                .Include(x => x.UserOrders)
                    .ThenInclude(x => x.Order)
                        .ThenInclude(x => x.Payment)
                .Include(x => x.UserOrders)
                    .ThenInclude(x => x.Order)
                        .ThenInclude(x => x.Shipment)
                .SingleOrDefaultAsync(x => x.Uid == uid);

            return user;
        }
    }
}
