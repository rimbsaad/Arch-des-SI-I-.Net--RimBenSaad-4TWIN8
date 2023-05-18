using AM.Applicationcore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using System;using AM.Applicationcore.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace AM.Applicationcore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane

    {
        private IUnitOfWork uow;
        public ServicePlane(IUnitOfWork uow) : base(uow)
        { 
            
        }

        public IList<Flight> GetFlights(int n)
        {
            return GetAll()
                .OrderByDescending(p=>p.PlaneId)
                .Take(n)
                .SelectMany(p=>p.Flights)
                .OrderBy(f=>f.FlightDate).ToList();
        }
        public IList<Passenger> GetPassenger(Plane p)
        {
            return GetById(p.PlaneId).Flights
               .SelectMany(f=>f.Tickets)
                .Select(p=>p.Passenger)
                .ToList();
        }

        public bool IsAvailablePlane(Flight flight,int n )
        {
            var capacity = flight.Plane.Capacity;
            var nbTicket = flight.Tickets.Count();
            return capacity > nbTicket;
            //select many pour avoir tous les tickets par contre select c'estu juste les tickets des vols relié à un vole donnée (précisé)
        }
        public void DeletePlanes()
        {
            DateTime tenYearsAgo = DateTime.Now.AddYears(-10);

            List<Plane> planes = (List<Plane>)GetAll(); 

            // Use LINQ to filter planes based on manufacture date
            List<Plane> planesToDelete = planes.Where(p => p.ManufactureDate < tenYearsAgo).ToList();

            foreach (Plane plane in planesToDelete)
            {
                // Perform the deletion logic for the plane, e.g., calling a delete method
                Delete(plane);
                Commit();
            }
        }


    }
}
