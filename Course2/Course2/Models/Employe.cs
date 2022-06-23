using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course2.Models
{
    public class Employe
    {
        public int EmployeId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Matricule { get; set; }
        public DateTime DateNaissance { get; set; }

    }
}