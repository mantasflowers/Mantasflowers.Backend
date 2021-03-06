using System.Threading.Tasks;
using Mantasflowers.Persistence;
using Mantasflowers.Services.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Mantasflowers.Services.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;
        private readonly IProductRepository _productRepository;
        private readonly IProductReviewRepository _productReviewRepository;
        private readonly IUserRepository _userReviewRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IHashMapRepository _hashMapRepository;
        private readonly IUserOrderRepository _userOrderRepository;
        private readonly IFeedbackRepository _feedbackRepository;

        public UnitOfWork(
            DatabaseContext dbContext,
            IProductRepository productRepository,
            IProductReviewRepository productReviewRepository,
            IUserRepository userReviewRepository,
            ICouponRepository couponRepository,
            IOrderRepository orderRepository,
            IShipmentRepository shipmentRepository,
            IPaymentRepository paymentRepository,
            IHashMapRepository hashMapRepository,
            IUserOrderRepository userOrderRepository,
            IFeedbackRepository feedbackRepository)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
            _productReviewRepository = productReviewRepository;
            _userReviewRepository = userReviewRepository;
            _couponRepository = couponRepository;
            _orderRepository = orderRepository;
            _shipmentRepository = shipmentRepository;
            _paymentRepository = paymentRepository;
            _hashMapRepository = hashMapRepository;
            _userOrderRepository = userOrderRepository;
            _feedbackRepository = feedbackRepository;
        }


        public IProductRepository ProductRepository
            => _productRepository;

        public IProductReviewRepository ProductReviewRepository
            => _productReviewRepository;

        public IUserRepository UserRepository
            => _userReviewRepository;

        public ICouponRepository CouponRepository
            => _couponRepository;

        public IOrderRepository OrderRepository
            => _orderRepository;

        public IShipmentRepository ShipmentRepository
            => _shipmentRepository;

        public IPaymentRepository PaymentRepository
            => _paymentRepository;

        public IHashMapRepository HashMapRepository
            => _hashMapRepository;

        public IUserOrderRepository UserOrderRepository
            => _userOrderRepository;

        public IFeedbackRepository FeedbackRepository
            => _feedbackRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public IExecutionStrategy CreateExecutionStrategy()
        {
            return _dbContext.Database.CreateExecutionStrategy();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }
    }
}