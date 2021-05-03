using AutoMapper;
using Mantasflowers.Contracts.Coupon.Request;
using Mantasflowers.Contracts.Coupon.Response;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.WebApi.Setup.Mapping
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<PostCreateCouponRequest, Coupon>()
                .ForMember(d => d.EndDate, opt => opt.MapFrom(s => s.RedeemBy));

            CreateMap<Stripe.PromotionCode, PostCreateCouponResponse>()
                .ForMember(d => d.RedeemBy, opt => opt.MapFrom(d => d.Coupon.RedeemBy))
                .ForMember(d => d.DurationInMonths, opt => opt.MapFrom(d => d.Coupon.DurationInMonths))
                .ForMember(d => d.Duration, opt => opt.MapFrom(d => d.Coupon.Duration))
                .ForMember(d => d.Currency, opt => opt.MapFrom(d => d.Coupon.Currency))
                .ForMember(d => d.Name, opt => opt.MapFrom(d => d.Code))
                .ForMember(d => d.DiscountPrice, opt => opt.MapFrom(d => d.Coupon.AmountOff))
                .ForMember(d => d.OrderOverPrice, opt => opt.MapFrom(d => d.Restrictions.MinimumAmount));
        }
    }
}
