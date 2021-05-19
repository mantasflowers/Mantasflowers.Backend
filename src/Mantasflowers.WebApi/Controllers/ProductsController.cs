using System;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Errors;
using Mantasflowers.Contracts.Product.Request;
using Mantasflowers.Contracts.Product.Response;
using Mantasflowers.Services.Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mantasflowers.WebApi.Controllers
{
    [ApiController]
    [Route("/product")]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get paginated products.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(GetProductsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaginatedProducts([FromQuery] GetProductsRequest request)
        {
            var response = await _productService.GetPaginatedProductsAsync(request);

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetDetailedProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var response = await _productService.GetDetailedProductInfoAsync(id);

            if (response == null)
            {
                return NotFound("Product not found");
            }

            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(typeof(GetDetailedProductResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            var response = await _productService.CreateProductAsync(request);

            return Ok(response);
        }
    }
}