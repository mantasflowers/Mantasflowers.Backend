using Mantasflowers.Contracts.Common;
using Mantasflowers.Domain.Enums;

namespace Mantasflowers.Contracts.Order.Request
{
    public class UpdateOrderStatusRequest : VersionableDtoTemplate
    {
        public OrderStatus Status { get; set; }

        public string OrderStatusContext { get; set; }
    }
}
