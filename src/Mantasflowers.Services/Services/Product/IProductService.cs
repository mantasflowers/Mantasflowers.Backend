using System;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Product.Request;
using Mantasflowers.Contracts.Product.Response;

namespace Mantasflowers.Services.Services.Product
{
    public interface IProductService
    {
        Task<GetProductsResponse> GetPaginatedProductsAsync(GetProductsRequest request);

        Task<GetDetailedProductResponse> GetDetailedProductInfoAsync(Guid id);

        Task<GetDetailedProductResponse> CreateProductAsync(CreateProductRequest request);

        Task<GetDetailedProductResponse> UpdateProductAsync(Guid id, UpdateProductRequest request);

        Task DeleteProductAsync(Guid id);
    }
}