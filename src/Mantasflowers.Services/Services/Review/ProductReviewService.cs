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
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductReviewService(IProductReviewRepository reviewRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IList<GetProductReviewsResponse>> GetProductReviewsAsync(Guid productId)
        {
            if ((await _productRepository.GetAsync(productId)) == null)
            {
                return null;
            }

            var reviews = await _reviewRepository.GetReviewsWithUsersAsync(productId);

            var reviewsReponse = _mapper.Map<IList<GetProductReviewsResponse>>(reviews);

            return reviewsReponse;
        }
    }   
}