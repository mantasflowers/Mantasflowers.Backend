using System;

namespace Mantasflowers.Domain.Entities
{
    public class UserAddress : Address 
    {
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}