using System;

namespace Mantasflowers.Domain.Entities
{
    public class UserContactInfo : ContactInfo 
    {
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}