using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Mantasflowers.Contracts.Review;
using Mantasflowers.Services.Repositories;

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

        public async Task<IList<GetProductReviewsResponse>> GetProductReviewsAsync(Guid productId)
        {
            var reviews = await _reviewRepository.GetReviewsWithUsersAsync(productId);

            var reviewsReponse = _mapper.Map<IList<GetProductReviewsResponse>>(reviews);

            return reviewsReponse;
        }
    }   
}