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

        Task<int> SaveChangesAsync();

        IExecutionStrategy CreateExecutionStrategy();

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}