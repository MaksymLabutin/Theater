using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Theater.WebApi.Data;
using Theater.WebApi.Features.Spectacle.Commands;
using Theater.WebApi.Features.Spectacle.Dtos;

namespace Theater.WebApi.Features.Spectacle.Handlers
{
    public class CreateSpectacleCommandHandler : IRequestHandler<CreateSpectacleCommand, SpectacleDto>
    {
        public Task<SpectacleDto> Handle(CreateSpectacleCommand request, CancellationToken cancellationToken)
        {
            var spectacle = new Models.Spectacle
            {
                Id = SpectaclesDb.Spectacles.Max(_ => _.Id) + 1,
                Tickets = request.Tickets,
                Date = request.Date,
                Name = request.Name
            };

            SpectaclesDb.Spectacles.Add(spectacle);

            var dto = SpectaclesDb.Spectacles.Select(_ => new SpectacleDto()
            {
                Id = _.Id,
                Date = _.Date,
                Name = _.Name,
                Tickets = _.Tickets
            }).First(_ => _.Id == spectacle.Id);

            return Task.FromResult(dto);
        }
    }
}
