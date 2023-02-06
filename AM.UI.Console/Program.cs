using  AM.Applicationcore;
using AM.Applicationcore.Domain;
using System.Xml.Schema;

namespace AM.UI.Console

{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int? a = null;
            string? nom= System.Console.ReadLine();
            System.Console.WriteLine("Bonjour "+nom);
            int ageValue=-1;
            //while (ageValue == -1)
            //{
            //    var age = System.Console.ReadLine();
            //    int.TryParse(age, out ageValue);
            //}
            do
            {
                var age = System.Console.ReadLine();
                int.TryParse(age, out ageValue);
            } while (ageValue == -1);
            System.Console.WriteLine(ageValue + 1);

            Personne personne = new Personne();
            Personne etudiant = new Etudiant();

            personne.Nom = "4Twin8";

            personne.Login("pass", "conf");
            personne.Login("pass", "conf", "email");

            personne.getMyType();
            etudiant.getMyType();   

            personne.Email = "email";
            personne.Nom = "nom";
            Personne p = new Personne (1,"nom","prenom", DateTime.Now, "pass","conf","email");

            Personne p2 = new Personne()
            {
                Id = 1,
                Nom = "nom2",
                Prenom = "prenom",
                ConfirmPassword = "conf",
                Password = "pass",
                Datenaissance = DateTime.Now,
                Email= "email",

            };

            System.Console.WriteLine(p2);
            Plane plane = new Plane()
            {
                Capacity = 200,
                PalneType = planeType.Boing
            };
           // Plane plane1 = new Plane(20, DateTime.Now, planeType.AirBus);
            System.Console.WriteLine(plane);
            Passenger passenger = new Passenger()
            {
                FirstName= "Rim",
                LastName="Bs"
            };
            passenger.CheckProfile("Rim", "Bs");
            System.Console.WriteLine(passenger.CheckProfile("Rim", "Bs","grtgt"));


            Staff staff = new Staff();
            Traveller traveller = new Traveller();
            passenger.PassengerType();
            staff.PassengerType(); 
            traveller.PassengerType();
        }





    }
}