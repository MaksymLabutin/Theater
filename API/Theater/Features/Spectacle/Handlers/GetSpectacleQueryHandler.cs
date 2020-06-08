using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Theater.WebApi.Data;
using Theater.WebApi.Features.Spectacle.Dtos;
using Theater.WebApi.Features.Spectacle.Queries;

namespace Theater.WebApi.Features.Spectacle.Handlers
{
    public class GetSpectacleQueryHandler : IRequestHandler<GetSpectacleQuery, SpectacleDto>
    {
        public Task<SpectacleDto> Handle(GetSpectacleQuery request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            //todo check for null and thow NotFoundException
            var spectacle = SpectaclesDb.Spectacles.Select(_ => new SpectacleDto()
            {
                Date = _.Date,
                Id = _.Id,
                Name = _.Name,
                Tickets = _.Tickets - OrdersDb.Orders.Where(o => o.SpectacleId == _.Id).Sum(_ => _.Tickets)
            })
                .First(_ => _.Id == request.Id);
            return Task.FromResult(spectacle);

        }
    }
}
