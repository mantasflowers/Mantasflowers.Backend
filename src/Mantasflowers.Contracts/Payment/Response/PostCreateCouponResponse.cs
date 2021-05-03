using System;

namespace Mantasflowers.Contracts.Payment.Response
{
    public class PostCreateCouponResponse
    {
        public string Id { get; set; }
        
        public bool Active { get; set; }
        
        public string Name { get; set; }
        
        public DateTime Created { get; set; }
        
        public DateTime RedeemBy { get; set; }

        public long DurationInMonths { get; set; }

        public string Duration { get; set; }

        public string Currency { get; set; }

        public long DiscountPrice { get; set; }

        public long OrderOverPrice { get; set; }

        public long TimesRedeemed { get; set; }
    }
}
