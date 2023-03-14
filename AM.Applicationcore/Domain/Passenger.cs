using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AM.Applicationcore.Domain
{
    public class Passenger

    {
        public int  PassengerId {get;set;}
        [Display(Name = "date of birth"), DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Key, StringLength(7)]
        public int PassportNumber { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        public FullName FullName1 { get; set; }

        [RegularExpression("[0-9]{8}")]
        public int TelNumber { get; set; }

        public virtual IList<Ticket> Tickets { get; set; }
        public virtual IList<Seat> Seats { get; set; }
        public virtual IList<Reservation>Reservations { get; set; }


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
        //public bool CheckProfile(string FirstName, string LastName, string? EmailAddress=null)
        //{
        //    if (EmailAddress!=null) {
        //        return this.FirstName == FirstName && this.LastName == LastName && this.EmailAddress == EmailAddress;
        //    }
        //    else {
        //       return this.FirstName == FirstName && this.LastName == LastName;
        //    }
        //}
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }

    }
}
