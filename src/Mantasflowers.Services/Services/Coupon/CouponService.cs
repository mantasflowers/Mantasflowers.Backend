using AutoMapper;
using Mantasflowers.Contracts.Payment.Request;
using Mantasflowers.Services.DataAccess;
using Mantasflowers.Services.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Coupon
{
    public class CouponService : ICouponService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CouponService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Coupon> CreateCouponAsync(PostCreateCouponRequest request)
        {
            var coupon = _mapper.Map<Domain.Entities.Coupon>(request);

            try
            {
                coupon = await _unitOfWork.CouponRepository.CreateAsync(coupon);
            }
            catch (DbUpdateException)
            {
                throw new FailedToAddDatabaseResourceException("Failed to create coupon");
            }

            return coupon;
        }
    }
}
