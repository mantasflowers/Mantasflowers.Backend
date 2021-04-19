using Mantasflowers.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByUidAsync(string uid);

        Task<User> GetDetailedUserByUidAsync(string uid);

        Task<User> GetDetailedUserByIdAsync(Guid id);
    }
}
