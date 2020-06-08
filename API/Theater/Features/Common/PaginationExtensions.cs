using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater.WebApi.Features.Common
{
    public static class PaginationExtensions
    {

        public static Page<T> BuildPage<T>(
            this IEnumerable<T> list, 
            int? pageNumber, 
            int? pageSize)
        {
            _ = list ?? throw new ArgumentNullException(nameof(list));

            var page = pageNumber ?? 1;
            var count = pageSize ?? Page<T>.DefaultPageSize;

            var skip = (page - 1) * count;

            IEnumerable<T> pageItems =
                list.Skip(skip)
                    .Take(count);

            int total = list.Count();

            return new Page<T>(pageItems, total);
        }
         
        //todo add EF
        //public static async Task<Page<T>> LoadPageAsync<T>(
        //    this IQueryable<T> query,
        //    int? pageNumber,
        //    int? pageSize)
        //{
        //    _ = query ?? throw new ArgumentNullException(nameof(query));
        //    var page = pageNumber ?? 1;
        //    var count = pageSize ?? Page<T>.DefaultPageSize;

        //    var skip = (page - 1) * count;

        //    IEnumerable<T> pageItems =
        //        await query
        //            .Skip(skip)
        //            .Take(count)
        //            .ToListAsync()
        //            .ConfigureAwait(false);

        //    int total = await query
        //        .CountAsync()
        //        .ConfigureAwait(false);

        //    return new Page<T>(pageItems, total);
        //}

    }
}
