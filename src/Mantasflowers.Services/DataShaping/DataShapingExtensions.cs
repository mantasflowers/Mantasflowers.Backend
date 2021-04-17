using System;
using System.Linq;
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
    }
}