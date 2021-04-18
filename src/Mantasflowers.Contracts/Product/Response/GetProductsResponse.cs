using System.Collections.Generic;
using Mantasflowers.Contracts.Product.Enums;

namespace Mantasflowers.Contracts.Product.Response
{
    public class GetProductsResponse
    {
        public int CurrentPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public ProductOrderByOptions OrderedBy { get; set; }

        public bool OrderDescending { get; set; }

        public IList<GetProductResponse> Items { get; set; }
    }
}