using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Mantasflowers.Services.Repositories
{
    public class ProductReviewRepository : BaseRepository<ProductReview>, IProductReviewRepository
    {
        public ProductReviewRepository(DatabaseContext dbContext)
            : base(dbContext) {}

        public async Task<IList<ProductReview>> GetReviewsWithUsersAsync(Guid productId)
        {
            var reviews = await _dbContext.ProductReviews
                .Include(x => x.User)
                .Where(x => x.ProductId == productId)
                .ToListAsync();

            return reviews;
        }
    }   
}