using System.Collections.Generic;

namespace Mantasflowers.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual UserAddress Address { get; set; }

        public virtual UserContactInfo UserContactInfo { get; set; }

        public string Uid { get; set; } // Firebase user id

        public virtual IEnumerable<UserOrder> UserOrders { get; set; }

        public virtual IEnumerable<ProductReview> ProductReviews { get; set; }

        public byte[] RowVersion { get; set; }
    }
}