using System;

namespace Mantasflowers.Contracts.Review
{
    public class GetProductReviewsResponse
    {
        public Guid ProductId { get; set; }

        public DateTime Date { get; set; }

        public string UserFirstName { get; set; }

        public double ReviewScore { get; set; }

        public string ReviewText { get; set; }
    }
}