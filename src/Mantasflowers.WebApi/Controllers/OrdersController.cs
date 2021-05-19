using Mantasflowers.Contracts.Errors;
using Mantasflowers.Contracts.Order.Request;
using Mantasflowers.Contracts.Order.Response;
using Mantasflowers.Services.Services.Order;
using Mantasflowers.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.WebApi.Controllers
{
    [ApiController]
    [Route("/order")]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetDetailedOrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetailedOrderAsync(Guid id)
        {
            var response = await _orderService.GetDetailedOrderInfoAsync(id);

            if (response == null)
            {
                return NotFound("Order not found");
            }

            Response.Headers.AddETagHeader(response.RowVersion);

            return Ok(response);
        }

        [HttpPost("get-order")]
        [ProducesResponseType(typeof(GetDetailedOrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetailedOrderAsync(string password)
        {
            var response = await _orderService.GetDetailedOrderInfoAsync(password);

            Response.Headers.AddETagHeader(response.RowVersion);

            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [ProducesResponseType(typeof(GetOrdersResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaginatedOrders([FromQuery] GetOrdersRequest request)
        {
            var response = await _orderService.GetPaginatedOrdersAsync(request);

            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(GetDetailedOrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateOrderStatusAsync(Guid id,
            UpdateOrderStatusRequest request,
            [FromHeader] byte[] etag)
        {
            request.RowVersion = etag;

            var response = await _orderService.UpdateOrderStatusAsync(id, request);
            return Ok(response);
        }
    }
}
