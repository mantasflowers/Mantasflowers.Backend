using System;
using System.Collections.Generic;
using Mantasflowers.Domain.Enums;

namespace Mantasflowers.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public OrderStatus Status { get; set; }

        public Guid? ShipmentId { get; set; }
        public virtual Shipment Shipment { get; set; }

        public Guid? PaymentId { get; set; }
        public virtual Payment Payment { get; set; }

        public OrderType Type { get; set; }

        public string TemporaryPasswordHash { get; set; } // TODO: this might change. Just a placeholder

        public virtual IEnumerable<OrderItem> OrderItems { get; set; }
    }
}