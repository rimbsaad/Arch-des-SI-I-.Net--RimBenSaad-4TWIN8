using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Domain
{
    public class Passenger

    {
        public DateTime BirthDate { get; set; }
        public int PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelNumber { get; set; }

        public IList<Flight> flights { get; set; }

        public override string ToString()
        {
            return $"{BirthDate},{PassportNumber}";
        }
       /* public bool CheckProfile(string FirstName,string LastName) 
        {
          return this.FirstName==FirstName && this.LastName==LastName;
        }
        public bool CheckProfile(string FirstName, string LastName,string EmailAddress)
        {
            return this.FirstName == FirstName && this.LastName == LastName && this.EmailAddress==EmailAddress;
        }*/
        public bool CheckProfile(string FirstName, string LastName, string? EmailAddress=null)
        {
            if (EmailAddress!=null) {
                return this.FirstName == FirstName && this.LastName == LastName && this.EmailAddress == EmailAddress;
            }
            else {
               return this.FirstName == FirstName && this.LastName == LastName;
            }
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }

    }
}
