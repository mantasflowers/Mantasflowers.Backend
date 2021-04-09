using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.Services.Repositories
{
    public interface IProductReviewRepository : IBaseRepository<ProductReview>
    {
        Task<IList<ProductReview>> GetReviewsWithUsersAsync(Guid productId);
    }   
}