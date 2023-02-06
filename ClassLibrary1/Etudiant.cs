using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Etudiant : Personne
    {
        public string Classe { get; set; }
        public string Specialite { get; set; }
        public string Matricule { get; set; }
        public override void  GetMyType()
        {
            Console.WriteLine("Je suis un etudiant");
        }
    }
}
