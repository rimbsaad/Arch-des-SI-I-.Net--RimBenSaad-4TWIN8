using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Domain
{
    public class Ticket
    {

       // [ForeignKey("Passenger")]
        public int PassengerFk { get; set; }// prop clé étrangére 
        //[ForeignKey("Flight")]
        public int FlightFk { get; set; } // prop clé étrangére 
        public double Prix { get; set; }
        public string Siege { get; set; }
        public bool VIP { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual Passenger Passenger  { get; set; }
    }
}
