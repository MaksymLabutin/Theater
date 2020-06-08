using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Theater.WebApi.Features.Spectacle.Dtos;

namespace Theater.WebApi.Features.Spectacle.Commands
{
    public class CreateSpectacleCommand : IRequest<SpectacleDto>
    {
        public CreateSpectacleCommand(CreateSpectacleDto dto)
        {
            Name = dto.Name;
            Date = dto.Date;
            Tickets = dto.Tickets;
        }
        public string Name { get;  }
        public DateTime Date { get;  }
        public int Tickets { get;  }
    }
}
