using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater.WebApi.Features.Spectacle.Dtos
{
    public class UpdateSpectacleDto
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Tickets { get; set; }
    }
}
