using Mantasflowers.Contracts.Order.Enums;
using Mantasflowers.Domain.Entities;
using System.Collections.Generic;

namespace Mantasflowers.Services.Mapping
{
    public static class OrderMappings
    {
        public static readonly Dictionary<OrderOrderByOptions, string> OrderSortingMapping
            = new()
            {
                { OrderOrderByOptions.DATE_CREATED, nameof(Order.CreatedOn) },
                { OrderOrderByOptions.DATE_UPDATED, nameof(Order.UpdatedOn) },
            };
    }
}
