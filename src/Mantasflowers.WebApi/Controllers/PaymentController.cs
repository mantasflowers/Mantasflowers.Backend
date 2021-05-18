using Mantasflowers.Contracts.Errors;
using Mantasflowers.Contracts.Payment.Request;
using Mantasflowers.Contracts.Payment.Response;
using Mantasflowers.Services.Services.Payment;
using Mantasflowers.Services.Services.User;
using Mantasflowers.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.WebApi.Controllers
{
    [ApiController]
    [Route("/payment")]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;

        public PaymentController(
            IPaymentService paymentService,
            IUserService userService
            )
        {
            _paymentService = paymentService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("create-checkout-session")]
        [ProducesResponseType(typeof(PostCreateCheckoutSessionResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateCheckoutSessionAsync(PostCreateCheckoutSessionRequest request)
        {
            Guid? userId = null;

            if (User.Identity.IsAuthenticated)
            {
                string uid = User.GetUid();
                userId = (await _userService.GetUserByUidAsync(uid)).Id;
            }

            var response = await _paymentService.CreateCheckoutSessionAsync(request, userId);

            return StatusCode(StatusCodes.Status201Created, response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("create-coupon")]
        [ProducesResponseType(typeof(PostCreateCheckoutSessionResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateCouponAsync(PostCreateCouponRequest request)
        {
            var response = await _paymentService.CreateCouponAsync(request);

            return StatusCode(StatusCodes.Status201Created, response);
        }
    }
}
