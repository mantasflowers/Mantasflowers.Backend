using System;

namespace Mantasflowers.Domain.Entities
{
    public class ProductReview : BaseEntity
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public double ReviewScore { get; set; }
    }
}