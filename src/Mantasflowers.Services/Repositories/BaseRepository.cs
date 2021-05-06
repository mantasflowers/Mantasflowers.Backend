using System;
using System.Threading.Tasks;
using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace Mantasflowers.Services.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        protected readonly DatabaseContext _dbContext;

        public BaseRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            var entityEntry = _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            var result = _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var entityEntry = _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public virtual async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        } 

        public virtual IExecutionStrategy CreateExecutionStrategy()
        {
            return _dbContext.Database.CreateExecutionStrategy();
        }
    }
}