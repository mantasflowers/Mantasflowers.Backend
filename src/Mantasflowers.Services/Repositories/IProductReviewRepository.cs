using System;
using System.Threading.Tasks;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.Services.Repositories
{
    public interface IProductReviewRepository : IBaseRepository<ProductReview>
    {
        Task<(int count, double avgScore)?> GetReviewsAggregateForProductAsync(Guid productId);

        Task<ProductReview> GetReviewForUserAsync(Guid userId, Guid productId);

        Task CreateReviewForUserAsync(Guid userId, Guid productId, double score);
    }   
}