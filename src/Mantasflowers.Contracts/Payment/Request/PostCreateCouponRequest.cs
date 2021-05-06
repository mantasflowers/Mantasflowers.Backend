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

        public long DiscountPrice { get; set; }

        public long OrderOverPrice { get; set; }
    }
}
