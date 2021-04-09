using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Mantasflowers.Contracts.Product.Request;
using Mantasflowers.Contracts.Product.Response;
using Mantasflowers.Services.Repositories;

namespace Mantasflowers.Services.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductsResponse> GetPaginatedProductsAsync(GetProductsRequest request)
        {
            Expression<Func<Mantasflowers.Domain.Entities.Product, bool>> categoryFilter = 
                (x => request.Categories.Contains(x.Category));

            var paginatedProducts = await _productRepository.GetPaginatedLisFilteredAsync(request.Page,
                request.PageSize,
                categoryFilter);

            var paginatedProductsResponse = _mapper.Map<GetProductsResponse>(paginatedProducts);

            return paginatedProductsResponse;
        }
    }
}