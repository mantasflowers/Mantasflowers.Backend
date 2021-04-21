using System;
using System.Threading.Tasks;
using AutoMapper;
using Mantasflowers.Contracts.Review.Response;
using Mantasflowers.Services.Repositories;
using Mantasflowers.Services.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Mantasflowers.Services.Services.Review
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IProductReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ProductReviewService(IProductReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<GetProductReviewResponse> GetProductReviewsAsync(Guid productId)
        {
            var aggregate = await _reviewRepository.GetReviewsAggregateForProductAsync(productId);

            if (aggregate == null)
            {
                return null;
            }

            var response = new GetProductReviewResponse
            {
                Count = aggregate.Value.count,
                AverageScore = aggregate.Value.avgScore
            };

            return response;
        }

        public async Task<GetProductReviewForUserResponse> GetProductReviewForUserAsync(Guid userId, Guid productId)
        {
            var review = await _reviewRepository.GetReviewForUserAsync(userId, productId);
            var response = _mapper.Map<GetProductReviewForUserResponse>(review);

            return response;
        }

        // TODO: [NFR] transactions? Exception catching? (review could exist or concurrent create review requests)
        public async Task CreateReviewForUserAsync(Guid userId, Guid productId, double score)
        {
            try
            {
                await _reviewRepository.CreateReviewForUserAsync(userId, productId, score);
            }
            catch (DbUpdateException)
            {
                throw new FailedToAddDatabaseResourceException($"Failed to create review for product {productId}");
            }
        }
    }   
}