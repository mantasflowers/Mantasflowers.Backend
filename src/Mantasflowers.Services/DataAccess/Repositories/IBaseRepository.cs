using System;
using System.Threading.Tasks;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        Task<T> CreateAsync(T entity);

        Task<T> GetAsync(Guid id);

        T Update(T entity);

        void Delete(T entity);

        Task<int> SaveChangesAsync();
    }
}