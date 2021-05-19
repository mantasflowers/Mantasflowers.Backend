using System;
using System.Collections.Generic;
using Mantasflowers.Domain.Enums;

namespace Mantasflowers.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public ProductCategory Category { get; set; }

        public string ShortDescription { get; set; }

        public decimal Price { get; set; }

        public int LeftInStock { get; set; } // TODO: still unknown where we will get this from

        public decimal? DiscountPercent { get; set; }

        public string ThumbnailPictureUrl { get; set; }

        public byte[] RowVersion { get; set; }

        public Guid ProductInfoId { get; set; }
        public virtual ProductInfo ProductInfo { get; set; }

        public virtual IEnumerable<ProductReview> Reviews { get; set; }
    }
}