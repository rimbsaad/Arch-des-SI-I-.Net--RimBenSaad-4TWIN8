using AM.ApplicationCore.Interfaces;
using AM.Applicationcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Interfaces
{
    public interface IServicePlane : IService<Plane>
    {
        public IList<Passenger> GetPassenger(Plane p );
        public IList<Flight> GetFlights(int n);
        public bool IsAvailablePlane(Flight flight, int n);
        public void DeletePlanes();
    }
}
