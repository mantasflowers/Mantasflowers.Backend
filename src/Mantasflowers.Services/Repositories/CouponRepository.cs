using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;

namespace Mantasflowers.Services.Repositories
{
    public class CouponRepository : BaseRepository<Coupon>, ICouponRepository
    {
        public CouponRepository(DatabaseContext dbContext)
            : base(dbContext) { }
    }
}
