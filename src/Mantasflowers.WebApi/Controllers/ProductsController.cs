using System;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Errors;
using Mantasflowers.Contracts.Product.Request;
using Mantasflowers.Contracts.Product.Response;
using Mantasflowers.Services.Services.Product;
using Mantasflowers.WebApi.Extensions;
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

            Response.Headers.AddETagHeader(response.RowVersion);

            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(typeof(GetDetailedProductResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            var response = await _productService.CreateProductAsync(request);

            return StatusCode(StatusCodes.Status201Created, response);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(GetDetailedProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateProduct(Guid id,
            UpdateProductRequest request,
            [FromHeader] byte[] etag)
        {
            request.RowVersion = etag;

            var response = await _productService.UpdateProductAsync(id, request);
            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productService.DeleteProductAsync(id);

            return NoContent();
        }
    }
}