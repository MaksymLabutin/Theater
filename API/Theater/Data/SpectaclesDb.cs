using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.WebApi.Models;

namespace Theater.WebApi.Data
{
    public static class SpectaclesDb
    {
        //todo move to the DB
        public static List<Spectacle> Spectacles = new List<Spectacle>()
        {
                new Spectacle()
                {
                    Date = DateTime.Now,
                    Id = 1,
                    Name = "Spectacle 1",
                    Tickets = 140
                },
                new Spectacle()
                {
                    Date = DateTime.Now,
                    Id = 1,
                    Name = "Spectacle 2",
                    Tickets = 150
                },
                new Spectacle()
                {
                    Date = DateTime.Now,
                    Id = 1,
                    Name = "Spectacle 3",
                    Tickets = 160
                },
                new Spectacle()
                {
                    Date = DateTime.Now,
                    Id = 1,
                    Name = "Spectacle 4",
                    Tickets = 170
                },
                new Spectacle()
                {
                    Date = DateTime.Now,
                    Id = 1,
                    Name = "Spectacle 5",
                    Tickets = 10
                }
        };
    }
}
