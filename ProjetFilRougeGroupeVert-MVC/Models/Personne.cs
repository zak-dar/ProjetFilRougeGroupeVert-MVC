using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class Personne
    {
        public int Id { get; set; }
        public string PersonneType { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public DateTime? DateNaissance { get; set; }
        public Role Role { get; set; }

        public Personne(string nom, string prenom, string email, string motDePasse)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            MotDePasse = motDePasse;
        }

        public Personne()
        {
        }
    }

    public enum Role 
    {
        ADMIN,
        UTILISATEUR
    }



}
