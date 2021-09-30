using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class Canal
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public Thematique Theme { get; set; }
        public bool EstActif { get; set; }
        public List<Publication> Publications { get; set; }

        public Canal(string nom, Thematique theme)
        {
            Nom = nom;
            Theme = theme;
            EstActif = true;
        }

        public Canal()
        {
            EstActif = true;
        }

    }
    public enum Thematique
    {
        JAVA,
        Csharp,
        HTML_CSS
    }
}


