﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Domain
{
    public class Flight
    {
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }

        public int EstimatedDuration { get; set; }

        public int FlightStatus { get; set;}
        public string Pilote { get; set; }
        public virtual Plane Plane { get; set; }
        [ForeignKey("Plane")]
        public virtual int PlaneId { get; set; }
        public virtual  IList<Ticket> Tickets { get; set;}

        public override string ToString()
        {
            return $"{Destination},{Departure},{FlightId}";

        }
    }
}
