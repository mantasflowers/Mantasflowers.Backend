using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Repositories
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
    }
}
