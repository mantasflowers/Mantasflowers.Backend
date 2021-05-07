using System;
using System.Threading.Tasks;
using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;

namespace Mantasflowers.Services.DataAccess.Repositories
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
            var entityEntry = await _dbContext.AddAsync(entity);

            return entityEntry.Entity;
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public virtual T Update(T entity)
        {
            var entityEntry = _dbContext.Update(entity);

            return entityEntry.Entity;
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}