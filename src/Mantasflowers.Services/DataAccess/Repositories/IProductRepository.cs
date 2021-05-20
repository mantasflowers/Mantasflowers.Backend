using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Common;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<PagedModel<Product>> GetPaginatedFilteredOrderedListAsync(int page, int limit,
            Expression<Func<Product, bool>> filter, string orderByPropertyName, bool orderDescending);

        Task<Product> GetDetailedProductAsync(Guid id);

        public void UpdateOriginalInternalRowVersion(Product product, byte[] rowVersion);
    }
}