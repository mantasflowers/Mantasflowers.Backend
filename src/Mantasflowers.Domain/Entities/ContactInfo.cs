namespace Mantasflowers.Domain.Entities
{
    public abstract class ContactInfo : BaseEntity
    {
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}