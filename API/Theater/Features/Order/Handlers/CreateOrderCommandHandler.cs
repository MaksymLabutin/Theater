using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Server.HttpSys;
using Theater.WebApi.Data;
using Theater.WebApi.Features.Order.Commands;
using Theater.WebApi.Features.Order.Dtos;
using Theater.WebApi.Features.Spectacle.Commands;

namespace Theater.WebApi.Features.Order.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    { 
        public Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Models.Order
            {
                Tickets = request.Tickets,
                Email = request.Email,
                SpectacleId = request.SpectacleId,
                Id = OrdersDb.Orders.Count > 0 ? OrdersDb.Orders.Max(_ => _.Id) + 1 : 1
            };

            OrdersDb.Orders.Add(order);

            var dto = OrdersDb.Orders.Select(_ => new OrderDto()
            {
                Tickets = _.Tickets,
                Id = _.Id,
                Email = _.Email
            })
                .First(_ => order.Id == _.Id);

            return Task.FromResult(dto);
        }
    }
}
