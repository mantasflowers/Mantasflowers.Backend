using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Common;
using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;
using Mantasflowers.Services.DataShaping;
using Microsoft.EntityFrameworkCore;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext dbContext)
            : base(dbContext) {}

        public async Task<PagedModel<Product>> GetPaginatedFilteredOrderedListAsync(int page, int limit,
            Expression<Func<Product, bool>> filter, string orderByPropertyName, bool orderDescending = false)
        {
            var products = await _dbContext.Products
                .AsNoTracking()
                .Where(filter)
                .OrderByPropertyName(orderByPropertyName, orderDescending)
                .PaginateAsync(page, limit);

            return products;
        }

        public async Task<Product> GetDetailedProductAsync(Guid id)
        {
            var product = await _dbContext.Products
                .Include(x => x.ProductInfo)
                .SingleOrDefaultAsync(x => x.Id == id);

            return product;
        }
    }
}