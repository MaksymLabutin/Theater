using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Theater.WebApi.Features.Spectacle.Dtos;

namespace Theater.WebApi.Features.Spectacle.Queries
{
    public class GetSpectacleQuery : IRequest<SpectacleDto>
    {
        public GetSpectacleQuery(int id)
        {
            Id = id;
        }

        public int Id { get;  }
    }
}
