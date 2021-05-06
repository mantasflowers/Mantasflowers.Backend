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

        public UnitOfWork(
            DatabaseContext dbContext,
            IProductRepository productRepository,
            IProductReviewRepository productReviewRepository,
            IUserRepository userReviewRepository)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
            _productReviewRepository = productReviewRepository;
            _userReviewRepository = userReviewRepository;
        }


        public IProductRepository ProductRepository
            => _productRepository;

        public IProductReviewRepository ProductReviewRepository
            => _productReviewRepository;

        public IUserRepository UserRepository
            => _userReviewRepository;


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