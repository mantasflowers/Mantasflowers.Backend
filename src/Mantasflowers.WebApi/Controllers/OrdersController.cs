﻿using Mantasflowers.Contracts.Errors;
using Mantasflowers.Contracts.Order.Request;
using Mantasflowers.Contracts.Order.Response;
using Mantasflowers.Services.Services.Order;
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
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetailedOrderAsync(Guid id)
        {
            var response = await _orderService.GetDetailedOrderInfoAsync(id);

            if (response == null)
            {
                return NotFound("Order not found");
            }

            return Ok(response);
        }

        [HttpPost("get-order")]
        [ProducesResponseType(typeof(GetDetailedOrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetailedOrderAsync(string password)
        {
            var response = await _orderService.GetDetailedOrderInfoAsync(password);

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
    }
}
