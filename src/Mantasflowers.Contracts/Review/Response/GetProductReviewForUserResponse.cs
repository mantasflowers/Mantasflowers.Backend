using System;

namespace Mantasflowers.Contracts.Review.Response
{
    public class GetProductReviewForUserResponse
    {
        public Guid ProductId { get; set; }

        public double Score { get; set; }

        // mapped from BaseEntity.CreatedOn
        public DateTime SubmittedAt { get; set; }
    }
}