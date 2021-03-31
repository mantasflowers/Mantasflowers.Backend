using System;

namespace Mantasflowers.Domain.Entities
{
    public class Coupon : BaseEntity
    {
        public string Name { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; } // TODO: this should really be "Duration". Figure out how to convert such format back and forth from DB

        public decimal DiscountPrice { get; set; }

        public decimal OrderOverPrice { get; set; } // applies only for orders over this price
    }
}
