using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class Administrateur : Personne
    {
        public Administrateur(): base()
        {
            Role = Role.ADMIN;
        }

        public Administrateur(string nom, string prenom, string email, string motDePasse) : base(nom, prenom, email, motDePasse)
        {
            Role = Role.ADMIN;
        }

    }
}
