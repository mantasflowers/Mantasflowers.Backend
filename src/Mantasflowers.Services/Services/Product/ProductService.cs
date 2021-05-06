using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Mantasflowers.Contracts.Product.Request;
using Mantasflowers.Contracts.Product.Response;
using Mantasflowers.Services.Mapping;
using Mantasflowers.Services.DataAccess;
using static Mantasflowers.Services.Mapping.ProductMappings;

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
            Expression<Func<Mantasflowers.Domain.Entities.Product, bool>> categoryFilter = 
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
    }
}