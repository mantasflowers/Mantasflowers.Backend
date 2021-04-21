using System;

namespace Mantasflowers.Contracts.Review.Request
{
    public class PostProductReviewRequest
    {
        public Guid ProductId { get; set; }

        public double Score { get; set; }
    }
}