using System;

namespace Mantasflowers.Domain.Entities
{
    public class UserOrder : BaseEntity
    {
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}