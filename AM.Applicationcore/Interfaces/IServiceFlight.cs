using AM.Applicationcore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Interfaces
{
    public interface IServiceFlight : IService<Flight>
    {
        public void Add(Flight f);
        public IList<Flight> GetFlightsByDepartureDate(DateTime? departureDate);
        public IEnumerable<Flight> SortFlights();

    }
}
