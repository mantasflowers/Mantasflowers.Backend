namespace Mantasflowers.Domain.Entities
{
    public class ProductInfo : BaseEntity
    {
        public decimal Price { get; set; }

        public int LeftInStock { get; set; } // TODO: still unknown where we will get this from

        public decimal? DiscountPercent { get; set; }
    }
}