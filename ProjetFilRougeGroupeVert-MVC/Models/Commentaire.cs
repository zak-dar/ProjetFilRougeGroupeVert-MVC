using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class Commentaire
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? AuteurId { get; set; }
        public Utilisateur Auteur{ get; set; }
        public string Contenu { get; set; }
        public int? PublicationId { get; set; }
        public Publication Publication { get; set; }

        public Commentaire(Utilisateur auteur, string contenu)
        {

            Date = DateTime.Now;
            Auteur = auteur;
            Contenu = contenu;
        }
        public Commentaire()
        {
            Date = DateTime.Now;
        }
    }
}
