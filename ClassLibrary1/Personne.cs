using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Personne
    {
        public Personne()
        {
                
        }
        public Personne(int id, string nom, string prenom, DateTime dateNaissance, string password, string confirmPassword, string email)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Password = password;
            ConfirmPassword = confirmPassword;
            Email = email;
        }

        public int Id
        { get; set; }

        public string Nom
        {
            get;
            set;
        }
        public string Prenom
        {
            get;
            set;
        }
        public DateTime DateNaissance
        {
            get;
            set;
        }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }

        // surchaaage des méthodes 
        /* public bool Login(string password , string confirmPassword)
         {
             return this.Password == password && this.ConfirmPassword == confirmPassword;
         }
         public bool Login(string password, string confirmPassword,string mail)
         {
             return this.Password == password && this.ConfirmPassword == confirmPassword && this.Email == mail;      
         }*/
        public bool Login(string password, string confirmPassword, string? mail = null)
        {
            if (mail != null)
            {
                return this.Password == password && this.ConfirmPassword == confirmPassword && this.Email == mail;

            }
            else
                return this.Password == password && this.ConfirmPassword == confirmPassword;


        }
        public virtual void  GetMyType()
        {
            Console.WriteLine("Je suis une personne");
        }
        public override string ToString()
        {
            return $"{Id},{Nom},{Prenom}";
        }
    }
}
