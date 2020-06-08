using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Theater.WebApi.Data;
using Theater.WebApi.Features.Spectacle.Commands;

namespace Theater.WebApi.Features.Spectacle.Handlers
{
    public class UpdateSpectacleCommandHandler : IRequestHandler<UpdateSpectacleCommand>
    {
        public Task<Unit> Handle(UpdateSpectacleCommand request, CancellationToken cancellationToken)
        {
            //todo check for null and throw NotFoundException
            var spectacle = SpectaclesDb.Spectacles.First(_ => _.Id == request.Id);

            spectacle.Name = request.Name;
            spectacle.Date = request.Date;
            spectacle.Tickets = request.Tickets;

            return Task.FromResult(Unit.Value);
        }
    }
}
