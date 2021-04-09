using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Review;

namespace Mantasflowers.Services.Services.Review
{
    public interface IProductReviewService
    {
        Task<IList<GetProductReviewsResponse>> GetProductReviewsAsync(Guid productId);
    }   
}