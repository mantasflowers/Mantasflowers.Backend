using Mantasflowers.Contracts.Order.Enums;
using Mantasflowers.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Mantasflowers.Contracts.Order.Request
{
    public class GetOrdersRequest
    {
        [FromQuery(Name = "page")]
        public int Page { get; set; }

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; }

        [FromQuery(Name = "orderBy")]
        public OrderOrderByOptions OrderBy { get; set; } = OrderOrderByOptions.DATE_CREATED;

        [FromQuery(Name = "orderDescending")]
        public bool OrderDescending { get; set; } = false;

        [FromQuery(Name = "categories")]
        public IList<OrderStatus> Statuses { get; set; } = new List<OrderStatus>();
    }
}
