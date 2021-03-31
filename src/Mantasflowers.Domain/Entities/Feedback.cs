using System;

namespace Mantasflowers.Domain.Entities
{
    public class Feedback : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Text { get; set; }
    }
}
