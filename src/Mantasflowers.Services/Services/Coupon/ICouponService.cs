using Mantasflowers.Contracts.Coupon.Request;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Coupon
{
    public interface ICouponService
    {
        Task<Domain.Entities.Coupon> CreateCouponAsync(PostCreateCouponRequest request);

        Task<IDbContextTransaction> BeginTransactionAsync();

        IExecutionStrategy CreateExecutionStrategy();
    }
}
