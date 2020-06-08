using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Theater.WebApi.Data;
using Theater.WebApi.Features.Common;
using Theater.WebApi.Features.Spectacle.Dtos;
using Theater.WebApi.Features.Spectacle.Queries;

namespace Theater.WebApi.Features.Spectacle.Handlers
{
    public class GetSpectaclesQueryHandler : IRequestHandler<GetSpectaclesQuery, Page<SpectacleDto>>
    {
        public Task<Page<SpectacleDto>> Handle(GetSpectaclesQuery request, CancellationToken cancellationToken)
        {
            var spectacles = SpectaclesDb.Spectacles;

            if (!string.IsNullOrEmpty(request.Name))
            {
                spectacles = spectacles.Where(_ => _.Name.Contains(request.Name)).ToList();
            }

            if (request.Date != null)
            {
                spectacles = spectacles.Where(_ => _.Date == request.Date).ToList();
            }

            var page = spectacles
                .Select(_ => new SpectacleDto()
                {
                    Name = _.Name,
                    Date = _.Date,
                    Tickets = _.Tickets - OrdersDb.Orders.Where(o => o.SpectacleId == _.Id).Sum(_ => _.Tickets),
                    Id = _.Id
                })
                .BuildPage(request.Page, request.Count);

            return Task.FromResult(page);
        }
    }
}
