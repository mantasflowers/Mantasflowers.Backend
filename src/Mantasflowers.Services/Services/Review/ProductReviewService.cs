using System;
using System.Threading.Tasks;
using AutoMapper;
using Mantasflowers.Contracts.Review.Response;
using Mantasflowers.Services.DataAccess;
using Mantasflowers.Services.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Mantasflowers.Services.Services.Review
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetProductReviewResponse> GetProductReviewsAsync(Guid productId)
        {
            var aggregate = await _unitOfWork.ProductReviewRepository.GetReviewsAggregateForProductAsync(productId);

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
            var review = await _unitOfWork.ProductReviewRepository.GetReviewForUserAsync(userId, productId);
            var response = _mapper.Map<GetProductReviewForUserResponse>(review);

            return response;
        }

        // TODO: Check if user bought this item; ensure concurrent edit (edit should be separate PUT/PATCH)
        public async Task CreateReviewForUserAsync(Guid userId, Guid productId, double score)
        {
            try
            {
                await _unitOfWork.ProductReviewRepository.CreateReviewForUserAsync(userId, productId, score);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new FailedToAddDatabaseResourceException($"Failed to create review for product {productId}");
            }
        }
    }   
}