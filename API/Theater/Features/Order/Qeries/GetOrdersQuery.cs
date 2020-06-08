using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Theater.WebApi.Features.Order.Dtos;

namespace Theater.WebApi.Features.Order.Qeries
{
    //todo change to pages
    public class GetOrdersQuery : IRequest<IEnumerable<OrderDto>>
    {
    }
}
