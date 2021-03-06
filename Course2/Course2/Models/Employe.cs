using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Course2.Models
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

    }
}