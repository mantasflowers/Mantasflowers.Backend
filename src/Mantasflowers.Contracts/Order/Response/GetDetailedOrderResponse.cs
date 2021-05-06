using Mantasflowers.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Mantasflowers.Contracts.Order.Response
{
    public class GetDetailedOrderResponse
    {
        public Guid Id { get; set; }

        public OrderStatus Status { get; set; }

        public GetOrderAddressResponse Address { get; set; }

        public GetOrderContactDetailsResponse ContactDetails { get; set; }

        public string TemporaryPasswordHash { get; set; } // TODO: this might change. Just a placeholder

        public ulong OrderNumber { get; set; }

        public decimal? DiscountPrice { get; set; }

        public string Message { get; set; }

        public IList<GetOrderItemResponse> OrderItems { get; set; }
    }
}
