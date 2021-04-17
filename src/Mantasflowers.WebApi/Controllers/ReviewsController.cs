using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Errors;
using Mantasflowers.Contracts.Review;
using Mantasflowers.Services.Services.Review;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mantasflowers.WebApi.Controllers
{
    [ApiController]
    [Route("/review")]
    public class ReviewsController : ControllerBase
    {
        private readonly IProductReviewService _productReviewService;

        public ReviewsController(IProductReviewService productReviewService)
        {
            _productReviewService = productReviewService;
        }

        /// <summary>
        /// Get all reviews for a product.
        /// </summary>
        [HttpGet("{productId}")]
        [ProducesResponseType(typeof(IList<GetProductReviewsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProductReviews(Guid productId)
        {
            var response = await _productReviewService.GetProductReviewsAsync(productId);

            if (response == null)
            {
                return NotFound("Product not found");
            }

            return Ok(response);
        }
    }
}