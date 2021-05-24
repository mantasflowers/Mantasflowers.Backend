using Mantasflowers.Contracts.Errors;
using Mantasflowers.Contracts.Shipment.Request;
using Mantasflowers.Contracts.Shipment.Response;
using Mantasflowers.Services.Services.Shipment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mantasflowers.WebApi.Controllers
{
    [ApiController]
    [Route("/shipment")]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [AllowAnonymous]
        [HttpPost("get-quote")]
        [ProducesResponseType(typeof(GetQuotesResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetQuotes(GetQuotesRequest request)
        {
            var response = await _shipmentService.GetQuotes(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create-shipment")]
        [ProducesResponseType(typeof(CreateShipmentResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateShipment(CreateShipmentRequest request)
        {
            var response = await _shipmentService.CreateShipment(request);

            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("cancel-shipment")]
        [ProducesResponseType(typeof(CancelShipmentResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CancelShipment(CancelShipmentRequest request)
        {
            var response = await _shipmentService.CancelShipment(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("get-tracking-events")]
        [ProducesResponseType(typeof(GetTrackingEventsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTrackingEvents(GetTrackingEventsRequest request)
        {
            var response = await _shipmentService.GetTrackingEvents(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("get-payment-link")]
        [ProducesResponseType(typeof(GetPaymentLinkResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaymentLin(GetPaymentLinkRequest request)
        {
            var response = await _shipmentService.GetPaymentLink(request);

            return Ok(response);
        }
    }
}
