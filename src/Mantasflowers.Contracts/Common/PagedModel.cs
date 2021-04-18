using System.Collections.Generic;

namespace Mantasflowers.Contracts.Common
{
    public class PagedModel<T>
    {
        public const int MaxPageSize = 200;

        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int CurrentPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public IList<T> Items { get; set; } = new List<T>();
    }
}