using Mantasflowers.Contracts.Payment.Request;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Coupon
{
    public interface ICouponService
    {
        Task<Domain.Entities.Coupon> CreateCouponAsync(PostCreateCouponRequest request);
    }
}
