using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Mantasflowers.Contracts.Product.Request;
using Mantasflowers.Contracts.Product.Response;
using Mantasflowers.Services.Mapping;
using Mantasflowers.Services.DataAccess;
using static Mantasflowers.Services.Mapping.ProductMappings;
using Mantasflowers.Services.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Mantasflowers.Services.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetProductsResponse> GetPaginatedProductsAsync(GetProductsRequest request)
        {
            Expression<Func<Domain.Entities.Product, bool>> categoryFilter = 
                (x => request.Categories.Contains(x.Category));

            if (!ProductSortingMapping.TryGetValue(request.OrderBy, out var orderByPropertyName))
            {
                throw new MappingException($"No entity property mapping found for '{nameof(request.OrderBy)}'");
            }

            var paginatedProducts = await _unitOfWork.ProductRepository.GetPaginatedFilteredOrderedListAsync(request.Page,
                request.PageSize,
                categoryFilter,
                orderByPropertyName,
                request.OrderDescending);

            var paginatedProductsResponse = _mapper.Map<GetProductsResponse>(paginatedProducts,
                o => o.AfterMap((source, destination) => 
                {
                    destination.OrderedBy = request.OrderBy;
                    destination.OrderDescending = request.OrderDescending;
                }));

            return paginatedProductsResponse;
        }

        public async Task<GetDetailedProductResponse> GetDetailedProductInfoAsync(Guid id)
        {
            var product = await _unitOfWork.ProductRepository.GetDetailedProductAsync(id);

            var detailedProductResponse = _mapper.Map<GetDetailedProductResponse>(product);

            return detailedProductResponse;
        }

        public async Task<GetDetailedProductResponse> CreateProductAsync(CreateProductRequest request)
        {
            var product = _mapper.Map<Domain.Entities.Product>(request);

            await _unitOfWork.ProductRepository.CreateAsync(product);

            await _unitOfWork.SaveChangesAsync();

            var response = _mapper.Map<GetDetailedProductResponse>(product);

            return response;
        }

        public async Task<GetDetailedProductResponse> UpdateProductAsync(Guid id, UpdateProductRequest request)
        {
            var product = await _unitOfWork.ProductRepository.GetDetailedProductAsync(id);

            if (product == null)
            {
                throw new ProductNotFoundException($"Product {id} not found");
            }

            _mapper.Map(request, product);

            if (request.RowVersion != null)
            {
                _unitOfWork.ProductRepository.UpdateOriginalInternalRowVersion(product, request.RowVersion);
            }

            _unitOfWork.ProductRepository.Update(product);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ConcurrentEntityUpdateException($"Concurrent update on product {product.Id} was detected");
            }
            catch (DbUpdateException)
            {
                throw new FailedToAddDatabaseResourceException($"Failed to update product {product.Id}");
            }

            var response = _mapper.Map<GetDetailedProductResponse>(product);

            return response;
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _unitOfWork.ProductRepository.GetDetailedProductAsync(id);

            if (product == null)
            {
                throw new ProductNotFoundException($"Product {id} not found");
            }

            _unitOfWork.ProductRepository.Delete(product);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}