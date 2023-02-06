using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore
{
    public class Personne
    {
        public Personne()
        {
                
        }

        public Personne(int id, string nom, string prenom, DateTime datenaissance, string password, string confirmPassword, string email)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Datenaissance = datenaissance;
            Password = password;
            ConfirmPassword = confirmPassword;
            Email = email;
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime Datenaissance { get; set; }

        public string  Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }

        //public bool Login (string ConfirmPassword, string Password)
        //{
        //    return this.Password== Password && this.ConfirmPassword==this.ConfirmPassword;
        //}
        //public bool Login(string ConfirmPassword, string Password, string Email)
        //{
        //    return this.Password == Password && this.ConfirmPassword == this.ConfirmPassword && this.Email==Email;
        //}
        public bool Login(string ConfirmPassword, string Password, string? email = null)
        {
            if (email != null)
            {
                return this.Password == Password && this.ConfirmPassword == this.ConfirmPassword && this.Email == email;
            }
            else
                return this.Password == Password && this.ConfirmPassword == this.ConfirmPassword;

        }

        public virtual void getMyType()
        {
            Console.WriteLine("je suis une personne ");
        }
        public override string ToString()
        {
            return $"{Id},{Nom},{Prenom},{Datenaissance}";
        }
    }
  
}
