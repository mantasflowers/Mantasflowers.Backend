using Mantasflowers.Contracts.Order.Enums;
using System.Collections.Generic;

namespace Mantasflowers.Contracts.Order.Response
{
    public class GetOrdersResponse
    {
        public int CurrentPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public OrderOrderByOptions OrderedBy { get; set; }

        public bool OrderDescending { get; set; }

        public IList<GetOrderResponse> Items { get; set; }
    }
}
