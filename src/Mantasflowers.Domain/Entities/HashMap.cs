using System;

namespace Mantasflowers.Domain.Entities
{
    public class HashMap : BaseEntity
    {
        public string PasswordHash { get; set; }
       
        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
