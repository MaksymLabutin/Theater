using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.WebApi.Models;

namespace Theater.WebApi.Data
{
    public static class OrdersDb
    {

        //todo move to the DB
        public static List<Order> Orders = new List<Order>();
    }
}
