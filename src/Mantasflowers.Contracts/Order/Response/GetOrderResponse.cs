using Mantasflowers.Domain.Enums;
using System;

namespace Mantasflowers.Contracts.Order.Response
{
    public class GetOrderResponse
    {
        public Guid Id { get; set; }

        public OrderStatus Status { get; set; }

        public string OrderStatusContext { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string UniquePassword { get; set; }

        public ulong OrderNumber { get; set; }
    }
}
