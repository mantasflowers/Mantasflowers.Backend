using System;

namespace Mantasflowers.Domain.Entities
{
    public class OrderContactInfo : ContactInfo
    {
        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}