using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Titre { get; set; }
        public string Contenu { get; set; }
        public bool Validite { get; set; } = false;
        public int? AuteurId { get; set; }
        public Utilisateur Auteur { get; set; }
        public int? CanalId { get; set; }
        public Canal Canal { get; set; }
        public List<Commentaire> Commentaires { get; set; }

        public Publication(string titre, string contenu, Utilisateur auteur)
        {
            Titre = titre;
            Contenu = contenu;
            Auteur = auteur;
            Date = DateTime.Now;
        }
        public Publication()
        {
            Date = DateTime.Now;
        }

    }
}