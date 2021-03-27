using System.Collections.Generic;
using Mantasflowers.Domain.Enums;

namespace Mantasflowers.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public ProductCategory Category { get; set; }

        public string Description { get; set; }

        public ProductStatus Status { get; set; }

        // TODO: Featured/Discount/Coupon??? Maybe store that at the Order ???

        public string PictureName { get; set; } // TODO: assuming pictures are stored in FE

        public int LeftInStock { get; set; } // TODO: this may come from somewhere else if "Supplier" is introduced
    }
}