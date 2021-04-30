using System;

namespace Mantasflowers.Contracts.Common.Templates
{
    public abstract class OrderItemTemplate
    {
        // mapped from ProductId
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
