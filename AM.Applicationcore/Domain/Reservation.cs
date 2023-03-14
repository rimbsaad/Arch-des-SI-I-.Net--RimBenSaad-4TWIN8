using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Domain
{
    public class Reservation
    {
        
        public DateTime DateReservation { get; set; }

        public int PassengerFK { get; set; }

        public int SeatFK { get; set; }
        public virtual Passenger Passenger { get; set;}

        public virtual Seat Seat { get; set; }
    }
}
