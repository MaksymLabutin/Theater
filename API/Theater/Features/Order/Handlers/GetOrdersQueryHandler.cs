using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Theater.WebApi.Data;
using Theater.WebApi.Features.Order.Dtos;
using Theater.WebApi.Features.Order.Qeries;

namespace Theater.WebApi.Features.Order.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderDto>>
    {
        public Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = OrdersDb.Orders.Select(_ => new OrderDto()
            {
                Tickets = _.Tickets,
                Email = _.Email,
                Id = _.Id
            });

            return Task.FromResult(orders);
        }
    }
}
