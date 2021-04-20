using System;

namespace Mantasflowers.Domain.Entities
{
    public class OrderAddress : Address
    {
        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}