using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater.WebApi.Features.Order.Dtos
{
    public class CreateOrderDto
    {
        public string Email { get; set; }
        public int Tickets { get; set; }
        public int SpectacleId { get; set; } 
    }
}
