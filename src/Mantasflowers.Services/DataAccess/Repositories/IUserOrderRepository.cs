using Mantasflowers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public interface IUserOrderRepository : IBaseRepository<UserOrder>
    {
        Task<IList<UserOrder>> GetUserOrdersByUserId(Guid userId);
    }
}
