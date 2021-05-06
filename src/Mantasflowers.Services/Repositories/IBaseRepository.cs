using System;
using System.Threading.Tasks;
using Mantasflowers.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Mantasflowers.Services.Repositories
{
    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        Task<T> CreateAsync(T entity);

        Task<T> GetAsync(Guid id);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<IDbContextTransaction> BeginTransactionAsync();

        IExecutionStrategy CreateExecutionStrategy();
    }
}