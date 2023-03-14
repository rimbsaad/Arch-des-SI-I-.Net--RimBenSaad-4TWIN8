using  AM.Applicationcore;
using AM.Applicationcore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using System.Xml.Schema;

namespace AM.UI.Console

{
    internal class Program
    {
        static void Main(string[] args)
        {
            var am = new AmContext();

            //am.Flights.Add()

            foreach (var item in am.Flights.ToList())
            {
                System.Console.WriteLine("afficher item" + item.FlightId + item.plane.Capacity);

            }
        }
    }
}