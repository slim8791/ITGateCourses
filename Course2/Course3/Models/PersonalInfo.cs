using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Course3.Models
{
    public class PersonalInfo
    {
        public int PersonalInfoId { get; set; }
        public string Adresse { get; set; }
        public string Phone { get; set; }
        public int Matricule { get; set; }

    }
}