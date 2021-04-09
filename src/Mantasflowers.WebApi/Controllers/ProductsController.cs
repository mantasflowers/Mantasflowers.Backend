using System.Threading.Tasks;
using Mantasflowers.Contracts.Common;
using Mantasflowers.Contracts.Errors;
using Mantasflowers.Contracts.Product.Request;
using Mantasflowers.Contracts.Product.Response;
using Mantasflowers.Services.Services.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mantasflowers.WebApi.Controllers
{
    [ApiController]
    [Route("/product")]
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
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] GetProductsRequest request)
        {
            var response = await _productService.GetPaginatedProductsAsync(request);

            return Ok(response);
        }
    }
}