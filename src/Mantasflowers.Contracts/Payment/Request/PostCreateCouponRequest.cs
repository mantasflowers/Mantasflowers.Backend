using Newtonsoft.Json;
using System;

namespace Mantasflowers.Contracts.Payment.Request
{
    public class PostCreateCouponRequest
    {
        public string Name { get; set; }

        public long DurationInMonths { get; set; }

        [JsonIgnore]
        public DateTime BeginDate { get; set; }

        public DateTime RedeemBy { get; set; }

        public decimal DiscountPrice { get; set; }

        public decimal OrderOverPrice { get; set; }
    }
}
