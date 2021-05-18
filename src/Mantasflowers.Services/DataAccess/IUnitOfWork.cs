using System.Threading.Tasks;
using Mantasflowers.Services.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Mantasflowers.Services.DataAccess
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IProductReviewRepository ProductReviewRepository { get; }
        IUserRepository UserRepository { get; }
        ICouponRepository CouponRepository { get; }
        IOrderRepository OrderRepository { get; }
        IShipmentRepository ShipmentRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IHashMapRepository HashMapRepository { get; }
        IUserOrderRepository UserOrderRepository { get; }

        Task<int> SaveChangesAsync();

        IExecutionStrategy CreateExecutionStrategy();

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}