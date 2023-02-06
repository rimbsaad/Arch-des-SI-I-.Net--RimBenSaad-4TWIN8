using System;
using System.Collections.Generic;
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

        public int Capacity { get; set; }
        public  DateTime ManufactureDate { get; set; }
        public int PlainId { get; set; }
        public planeType PalneType { get; set; }

        IList<Flight> Flights { get; set;}
        public override string ToString()
        {
            return $"{Capacity},{ManufactureDate}, {PlainId}";
        }

        

    }
}
