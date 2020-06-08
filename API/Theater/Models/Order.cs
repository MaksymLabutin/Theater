using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater.WebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int SpectacleId { get; set; }
        public string UserName { get; set; }
        public int Tickets { get; set; }
    }
}
