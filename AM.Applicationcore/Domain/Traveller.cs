using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Domain
{
    public class Traveller : Passenger
    {
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }
        public override void PassengerType()
        {
            Console.WriteLine(" I am a passenger I am a traveller ");
        }
        public override string ToString()
        {
            return $"FirstName: {FirstName},LastName: {LastName},BirthDate : {BirthDate},PassportNumber : {PassportNumber}";
        }
    }
}
