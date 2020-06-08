﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater.WebApi.Models
{
    public class Spectacle
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public DateTime Date { get; set; }
        public int Tickets { get; set; }

        //todo status
    }
}
