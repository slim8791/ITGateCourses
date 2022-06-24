using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Course3.Models
{
    public class Employe
    {
        public int EmployeId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public DateTime DateNaissance { get; set; }
        [ForeignKey("PersonalInfo")]
        public int PersonalIfoId { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
        [ForeignKey("Projet")]
        public int ProjetId { get; set; }
        public virtual Projet Projet { get; set; }
        public virtual ICollection<Formation> formations { get; set; }
    }
}