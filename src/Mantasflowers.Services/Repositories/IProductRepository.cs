using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Common;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.Services.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<PagedModel<Product>> GetPaginatedFilteredListAsync(int page, int limit,
        Expression<Func<Product, bool>> filter);

        Task<Product> GetDetailedProductAsync(Guid id);
    }
}