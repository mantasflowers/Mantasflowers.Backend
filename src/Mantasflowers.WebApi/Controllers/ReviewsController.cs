using System;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Errors;
using Mantasflowers.Contracts.Review.Request;
using Mantasflowers.Contracts.Review.Response;
using Mantasflowers.Services.Services.Review;
using Mantasflowers.Services.Services.User;
using Mantasflowers.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mantasflowers.WebApi.Controllers
{
    [ApiController]
    [Route("/review")]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public class ReviewsController : ControllerBase
    {
        private readonly IProductReviewService _productReviewService;
        private readonly IUserService _userService;

        public ReviewsController(IProductReviewService productReviewService, IUserService userService)
        {
            _productReviewService = productReviewService;
            _userService = userService;
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(typeof(GetProductReviewResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductReviews(Guid productId)
        {
            var response = await _productReviewService.GetProductReviewsAsync(productId);

            if (response == null)
            {
                return NotFound("No reviews found for product");
            }

            return Ok(response);
        }

        /// <summary>
        /// Get logged-in users product review.
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(GetProductReviewForUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductReviewForUser([FromQuery] Guid productId)
        {
            var uid = User.GetUidFromJwt();
            
            var user = await _userService.GetUserByUidAsync(uid);
            var response = await _productReviewService.GetProductReviewForUserAsync(user.Id, productId);

            if (response == null)
            {
                return NotFound("Review not found");
            }

            return Ok(response);
        }

        /// <summary>
        /// Create user review for a product. TODO: check if user has purchased this product.
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PostProductReview(PostProductReviewRequest request)
        {
            var uid = User.GetUidFromJwt();
            
            var user = await _userService.GetUserByUidAsync(uid);
            await _productReviewService.CreateReviewForUserAsync(user.Id, request.ProductId, request.Score);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}