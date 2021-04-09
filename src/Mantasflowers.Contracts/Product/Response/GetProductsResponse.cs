using System.Collections.Generic;

namespace Mantasflowers.Contracts.Product.Response
{
    public class GetProductsResponse
    {
        public int CurrentPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public IList<GetProductResponse> Items { get; set; }
    }
}