using System;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Review.Response;

namespace Mantasflowers.Services.Services.Review
{
    public interface IProductReviewService
    {
        Task<GetProductReviewResponse> GetProductReviewsAsync(Guid productId);

        Task<GetProductReviewForUserResponse> GetProductReviewForUserAsync(Guid userId, Guid productId);

        Task CreateReviewForUserAsync(Guid userId, Guid productId, double score);
    }   
}