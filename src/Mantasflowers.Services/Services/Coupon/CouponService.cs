using AutoMapper;
using Mantasflowers.Contracts.Payment.Request;
using Mantasflowers.Services.Repositories;
using Mantasflowers.Services.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Coupon
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;

        public CouponService(ICouponRepository couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Coupon> CreateCouponAsync(PostCreateCouponRequest request)
        {
            var coupon = _mapper.Map<Domain.Entities.Coupon>(request);

            try
            {
                coupon = await _couponRepository.CreateAsync(coupon);
            }
            catch (DbUpdateException)
            {
                throw new FailedToAddDatabaseResourceException("Failed to create coupon");
            }

            return coupon;
        }

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return _couponRepository.BeginTransactionAsync();
        }

        public IExecutionStrategy CreateExecutionStrategy()
        {
            return _couponRepository.CreateExecutionStrategy();
        }
    }
}
