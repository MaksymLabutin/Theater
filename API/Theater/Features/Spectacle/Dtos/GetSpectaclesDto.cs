using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater.WebApi.Features.Spectacle.Dtos
{
    public class GetSpectaclesDto
    { 
        public int? Page { get; set; }
        public int? Count { get; set; }
        public DateTime? Date { get; set; }
        public string Name { get; set; }
    }
}
