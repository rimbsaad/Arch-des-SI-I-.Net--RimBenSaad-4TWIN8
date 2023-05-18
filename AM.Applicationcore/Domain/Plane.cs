using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Domain
{
    public enum planeType
    {
        Boing,
        AirBus
    }
    public class Plane
    {
        public Plane()
        {
          

        }

        /*public Plane(int capacity, DateTime manufactureDate, planeType palneType)
        {
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            PalneType = palneType;
        }*/
        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }
        public  DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public planeType PlaneType { get; set; }
        [NotMapped]
        public string? Information { get { return ManufactureDate + " " + Capacity + " " + PlaneId; } }
        public virtual IList<Flight> Flights { get; set;}


        public virtual IList<Seat> Seats { get; set; }

        public override string ToString()
        {
            return $"{Capacity},{ManufactureDate}, {PlaneId}";
        }

        

    }
}
