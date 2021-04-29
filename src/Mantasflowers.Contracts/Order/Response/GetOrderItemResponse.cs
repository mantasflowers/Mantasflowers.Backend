using System;

namespace Mantasflowers.Contracts.Order.Response
{
    public class GetOrderItemResponse
    {
        // mapped from ProductId
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
