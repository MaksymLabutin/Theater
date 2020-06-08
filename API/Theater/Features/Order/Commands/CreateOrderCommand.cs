using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Theater.WebApi.Features.Order.Dtos;

namespace Theater.WebApi.Features.Order.Commands
{
    public class CreateOrderCommand: IRequest<OrderDto>
    {
        public CreateOrderCommand(CreateOrderDto dto)
        {
            Email = dto.Email;
            Tickets = dto.Tickets;
            SpectacleId = dto.SpectacleId;
        }

        public string Email { get; }
        public int Tickets { get;  }
        public int SpectacleId { get;  }
    }
}
