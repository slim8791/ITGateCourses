using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Course3.Models
{
    public class Formation
    {
        [Key]
        public int FormationId { get; set; }
        public string Intitule { get; set; }
        public DateTime DateDebut { get; set; }
        public virtual ICollection<Employe> Employes { get; set; }
        
    }
}