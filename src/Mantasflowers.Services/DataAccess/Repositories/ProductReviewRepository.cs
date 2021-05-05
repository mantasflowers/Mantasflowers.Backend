using System;
using System.Linq;
using System.Threading.Tasks;
using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public class ProductReviewRepository : BaseRepository<ProductReview>, IProductReviewRepository
    {
        public ProductReviewRepository(DatabaseContext dbContext)
            : base(dbContext) {}

        public async Task<(int count, double avgScore)?> GetReviewsAggregateForProductAsync(Guid productId)
        {
            var aggregate = await _dbContext.ProductReviews
                .GroupBy(x => x.ProductId)
                .Where(x => x.Key == productId)
                .Select(x => new {
                    Count = x.Count(),
                    Average = x.Average(y => y.ReviewScore)
                })
                .FirstOrDefaultAsync();

            if (aggregate == null)
            {
                return null;
            }

            return (aggregate.Count, aggregate.Average);
        }

        public async Task<ProductReview> GetReviewForUserAsync(Guid userId, Guid productId)
        {
            var review = await _dbContext.ProductReviews
                .Where(x => x.UserId == userId && x.ProductId == productId)
                .FirstOrDefaultAsync();

            return review;
        }

        public async Task CreateReviewForUserAsync(Guid userId, Guid productId, double score)
        {
            var review = new ProductReview
            {
                UserId = userId,
                ProductId = productId,
                ReviewScore = score,
            };

            await CreateAsync(review);
        }
    }   
}