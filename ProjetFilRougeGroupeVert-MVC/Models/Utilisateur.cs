using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class Utilisateur : Personne
    {
        public bool Valide { get; set; }
        public List<Publication> Publications { get; set; }
        public List<Commentaire> Commentaires { get; set; }
        public Utilisateur() : base()
        {
            Valide = false;
            Role = Role.UTILISATEUR;

        }

        public Utilisateur(string nom, string prenom, string email, string motDepasse) : base(nom, prenom, email, motDepasse)
        { 
            Valide = false;
            Role = Role.UTILISATEUR;
        }


    }
}