using System;
using System.Collections.Generic;
using Mantasflowers.Domain.Enums;

namespace Mantasflowers.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsRegistered { get; set; }

        public Guid? AddressId { get; set; }
        public virtual UserAddress Address { get; set; }

        public Guid? ContactsId { get; set; }
        public virtual UserContactInfo Contacts { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }

        public virtual IEnumerable<ProductReview> ProductReviews { get; set; }
    
        // TODO: Roles? Separate table?
    }
}