using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater.WebApi.Features.Order.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Tickets { get; set; }
    }
}
