using Mantasflowers.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByUidAsync(string uid);

        void UpdateOriginalInternalRowVersion(User user, byte[] rowVersion);

        Task<User> GetDetailedUserByUidAsync(string uid);

        Task<User> GetDetailedUserByIdAsync(Guid id);
    }
}
