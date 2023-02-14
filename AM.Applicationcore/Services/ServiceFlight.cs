using AM.Applicationcore.Domain;
using AM.Applicationcore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        /*List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> result = new List<DateTime>();
            for (int i = 0; i < Flights.Count; i++)
            {
                Flight flight = Flights[i];
                if (flight.Destination == destination)
                {
                    result.Add(flight.FlightDate);
                }
            }
            return result;
        }*/

        /*IEnumerable<DateTime> GetFlightDates(string destination)
        {
            for (int i = 0; i < Flights.Count; i++)
            {
                Flight flight = Flights[i];
                if (flight.Destination == destination)
                {
                    yield return flight.FlightDate;
                }
            }
        }

        IEnumerable<DateTime> GetFlightDates(string destination)
        {
            foreach (var flight in Flights)
            {
                if (flight.Destination == destination)
                {
                    yield return flight.FlightDate;
                }
            }
        }
        IEnumerable<DateTime> GetFlightDates1(string destination) { 
        IEnumerable<DateTime> query =
           from f in Flights
           where f.Destination == destination
           select f.FlightDate;
            return query;
       }
        IEnumerable<DateTime> GetFlightDates2(string destination)
        {
            return Flights.Where(f=> f.Destination == destination).Select(f => f.FlightDate);
        }
        void ShowFlightDetails(Plane plane)
        {
            var query = from p in Flights
                        where p.plane.PlainId== plane.PlainId   
                        select p;

            foreach (var item in query)
            {
                Console.WriteLine(item.FlightDate+item.Destination);
            }
        }
        void ShowFlightDetails1(Plane plane)
        {

            return Flights.Where(f => f.plane.PlainId == plane.PlainId).Select(f => f.FlightDate + f.Destination).ToString();
        }
        public int   ProgrammedFlightNumber(DateTime startDate)
        {
            var query = (from f in Flights
                        where (startDate - f.FlightDate).TotalDays < 7 && startDate <= f.FlightDate
                        select f).Count();
            return query;

            return Flights.Count(f => (startDate - f.FlightDate).TotalDays < 7 && startDate <= f.FlightDate);

          }
        //     return Flights.Count(f => f.flightDate<=startDate.adddays(7) && startDate <= f.FlightDate);

        public double DurationAverage(string destination)
        {
            return Flights.Where(f => f.Destination == destination).Average(f=>f.EstimatedDuration);
        }
        IEnumerable<Flight> OrderedDurationFlights()
        {
            return Flights.OrderByDescending(f=>f.EstimatedDuration);
        }*/


        public static IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            List<Traveller> Travellers = flight.Passengers.OfType<Traveller>().ToList();
            return Travellers.OrderBy(t => t.BirthDate).Take(3);

            //return Flights.Select(f => f.Passengers.OfType<Traveller>()).OrderBy((f, keySelector ) => Func(f, keySelector);

        }





        //public void GetFlights(string filterType, string filterValue)
        //{
        //    switch (filterType)
        //    {
        //        case "Destination":
        //            {
        //                var result = Flights.Where(f => f.Destination == filterValue).ToList();
        //                foreach (var f in result)
        //                {
        //                    Console.WriteLine(f);
        //                }
        //            }
        //            break;
        //        case "Departure":
        //            {
        //                var result = Flights.Where(f => f.Departure == filterValue).ToList();
        //                foreach (var f in result)
        //                {
        //                    Console.WriteLine(f);
        //                }
        //            }
        //            break;
        //        case "FlightDate":
        //            {
        //                var result = Flights.Where(f => f.FlightDate == DateTime.Parse(filterValue)).ToList();
        //                foreach (var f in result)
        //                {
        //                    Console.WriteLine(f);
        //                }
        //            }
        //            break;
        //        case "FlightId":
        //            {
        //                var result = Flights.Where(f => f.FlightId == int.Parse(filterValue)).ToList();
        //                foreach (var f in result)
        //                {
        //                    Console.WriteLine(f);
        //                }
        //            }
        //            break;
        //        case "EffectiveArrival":
        //            {
        //                var result = Flights.Where(f => f.EffectiveArrival == DateTime.Parse(filterValue)).ToList();
        //                foreach (var f in result)
        //                {
        //                    Console.WriteLine(f);
        //                }
        //            }
        //            break;
        //        case "EstimatedDuration":
        //            {
        //                var result = Flights.Where(f => f.EstimatedDuration == int.Parse(filterValue)).ToList();
        //                foreach (var f in result)
        //                {
        //                    Console.WriteLine(f);
        //                }
        //            }
        //            break;
        //    }
        //}


        //public void GetFlights1(string filterValue, Func<string, Flight, bool> condition)
        //{

        //    foreach (var f in Flights)
        //    {
        //        if (condition(filterValue, f))
        //            Console.WriteLine(f);
        //    }

        //}

    }
}