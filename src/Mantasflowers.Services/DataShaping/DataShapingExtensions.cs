using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Common;
using Microsoft.EntityFrameworkCore;

namespace Mantasflowers.Services.DataShaping
{
    public static class DataShapingExtensions
    {
        public static async Task<PagedModel<T>> PaginateAsync<T>(
            this IQueryable<T> query,
            int page,
            int limit
        ) where T : class, new()
        {
            var pagedResponse = new PagedModel<T>();

            page = (page < 0) ? 1 : page;
            limit = (limit < 0) ? PagedModel<T>.MaxPageSize : limit;

            pagedResponse.CurrentPage = page;
            pagedResponse.PageSize = limit;

            var skipCount = (page - 1) * limit;
            pagedResponse.Items = await query
                .Skip(skipCount)
                .Take(limit)
                .ToListAsync();

            pagedResponse.TotalItems = await query.CountAsync();
            pagedResponse.TotalPages = (int)Math.Ceiling(pagedResponse.TotalItems / (double)limit);

            return pagedResponse;
        }

        public static IQueryable<T> OrderByPropertyName<T>(
            this IQueryable<T> query,
            string name,
            bool descending = false
        )
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return query;
            }

            var modelPropertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var sortablePropertyInfo = modelPropertyInfos.FirstOrDefault(x =>
                x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            
            if (sortablePropertyInfo == null)
            {
                return query;
            }

            string sortingOrder = descending ? "descending" : "ascending";
            string orderByQuery = $"{sortablePropertyInfo.Name} {sortingOrder}";

            return query.OrderBy(orderByQuery);
        }
    }
}