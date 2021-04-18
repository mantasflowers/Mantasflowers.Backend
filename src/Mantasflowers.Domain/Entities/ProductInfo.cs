namespace Mantasflowers.Domain.Entities
{
    public class ProductInfo : BaseEntity
    {
        public string Description { get; set; }

        public string PictureUrl { get; set; } // TODO: this can just be url1;url2;...if needed 
    }
}