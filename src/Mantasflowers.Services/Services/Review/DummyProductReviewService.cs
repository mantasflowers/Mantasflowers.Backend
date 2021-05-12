using System;
using System.Linq;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Review.Response;
using Mantasflowers.Persistence;
using Mantasflowers.Services.Services.Exceptions;

namespace Mantasflowers.Services.Services.Review
{
    /// <summary>
    /// Dummy class for showcasing JSON based DI registration without recompiling.
    /// </summary>
    public class DummyProductReviewService : IProductReviewService
    {
        private readonly DatabaseContext _databaseContext;

        public DummyProductReviewService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task<GetProductReviewResponse> GetProductReviewsAsync(Guid productId)
        {
            var response = new GetProductReviewResponse
            {
                Count = 123,
                AverageScore = 8.4
            };

            return Task.FromResult(response);
        }

        public Task<GetProductReviewForUserResponse> GetProductReviewForUserAsync(Guid userId, Guid productId)
        {
            var response = new GetProductReviewForUserResponse
            {
                ProductId = _databaseContext.Products.First().Id,
                Score = 6.5,
                SubmittedAt = DateTime.UtcNow,
            };

            return Task.FromResult(response);
        }

        public Task CreateReviewForUserAsync(Guid userId, Guid productId, double score)
        {
            throw new FailedToAddDatabaseResourceException($"This dummy service doesn't implement review creation");
        }
    }
}