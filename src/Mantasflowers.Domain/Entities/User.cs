using System;
using System.Collections.Generic;

namespace Mantasflowers.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid? AddressId { get; set; }
        public virtual UserAddress Address { get; set; }

        public Guid? UserContactInfoId { get; set; }
        public virtual UserContactInfo UserContactInfo { get; set; }

        public virtual IEnumerable<UserOrder> UserOrders { get; set; }

        public virtual IEnumerable<ProductReview> ProductReviews { get; set; }
    
        // TODO: Roles? Separate table?
    }
}