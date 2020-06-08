using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Theater.WebApi.Features.Spectacle.Dtos;

namespace Theater.WebApi.Features.Spectacle.Commands
{
    public class UpdateSpectacleCommand : IRequest
    {
        public UpdateSpectacleCommand(UpdateSpectacleDto dto, int id)
        {
            Id = id;
            Name = dto.Name;
            Date = dto.Date;
            Tickets = dto.Tickets;
        }

        public int Id { get;  }
        public string Name { get;  }
        public DateTime Date { get;  }
        public int Tickets { get;  }
    }
}
