using System.Collections.Generic;

namespace Mantasflowers.Contracts.Order.Response
{
    public class GetUserOrdersResponse
    {
        public IList<GetOrderResponse> UserOrders { get; set; }
    }
}
