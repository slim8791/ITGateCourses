using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbFirstCore.Models
{
    [Table("Grade")]
    public partial class Grade
    {
        [Key]
        public int GradeId { get; set; }
        public string? GradeName { get; set; }
        public string? Section { get; set; }
    }
}
