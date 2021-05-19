using System;
using System.Collections.Generic;
using Mantasflowers.Domain.Enums;

namespace Mantasflowers.Domain.Entities
{
    public class Order : BaseEntity
    {
        public OrderStatus Status { get; set; } = OrderStatus.UNPAID;

        public Guid? ShipmentId { get; set; }
        public virtual Shipment Shipment { get; set; }

        public Guid? PaymentId { get; set; }
        public virtual Payment Payment { get; set; }

        public virtual OrderAddress OrderAddress { get; set; }

        public virtual OrderContactInfo OrderContactInfo { get; set; }

        public string UniquePassword { get; set; }

        public ulong OrderNumber { get; set; }

        public decimal? DiscountPrice { get; set; }

        public string Message { get; set; }

        public byte[] RowVersion { get; set; }

        public virtual IEnumerable<OrderItem> OrderItems { get; set; }
    }
}