using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course3.Models
{
    public class Projet
    {
        public int ProjetId { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Employe> Employes { get; set; }

        public Projet()
        {
            this.Employes = new List<Employe>();
        }
    }
}