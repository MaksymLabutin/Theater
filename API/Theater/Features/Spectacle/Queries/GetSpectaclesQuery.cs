using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Theater.WebApi.Features.Common;
using Theater.WebApi.Features.Spectacle.Dtos;

namespace Theater.WebApi.Features.Spectacle.Queries
{
    public class GetSpectaclesQuery : IRequest<Page<SpectacleDto>>
    {
        public GetSpectaclesQuery(GetSpectaclesDto dto)
        {
            Page = dto.Page;
            Count = dto.Count;
            Date = dto.Date;
            Name = dto.Name;
        }

        public int? Page { get; }
        public int? Count { get; }
        public DateTime? Date { get; }
        public string Name { get; }
    }
}
