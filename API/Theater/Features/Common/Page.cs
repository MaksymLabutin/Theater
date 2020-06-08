using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater.WebApi.Features.Common
{
    public class Page<T>
    {
        public const int DefaultPageSize = 10;

        public const int MaxPageSize = 1000;

        public Page(IEnumerable<T> items, int total)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
            Total = total;
        }
        public int Total { get; }

        public IEnumerable<T> Items { get; }
    }
}
