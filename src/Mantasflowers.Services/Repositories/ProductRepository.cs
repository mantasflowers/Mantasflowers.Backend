using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Common;
using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;
using Mantasflowers.Services.DataShaping;
using Microsoft.EntityFrameworkCore;

namespace Mantasflowers.Services.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<PagedModel<Product>> GetPaginatedFilteredListAsync(int page, int limit,
            Expression<Func<Product, bool>> filter)
        {
            var products = await _dbContext.Products
                .AsNoTracking()
                .Where(filter) // TODO: check the actual SQL query I get from this nonsense
                .PaginateAsync(page, limit);

            return products;
        }
    }
}