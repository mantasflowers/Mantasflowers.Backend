using System;
using System.Collections.Generic;
using Mantasflowers.Domain.Enums;

namespace Mantasflowers.Domain.Entities
{
    public class Product : BaseEntity
    {
        
        public string Name { get; set; }

        public ProductCategory Category { get; set; }

        public string Description { get; set; }

        public string PictureName { get; set; } // TODO: assuming pictures are stored in FE

        public Guid ProductInfoId { get; set; }
        public virtual ProductInfo ProductInfo { get; set; }

        public virtual IEnumerable<ProductReview> Reviews { get; set; }
    }
}