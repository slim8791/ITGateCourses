using Course3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Course3.Data
{
    public class Course3Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Course3Context() : base("name=Course3Context")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Une dexième méthode de création d'une relation One to Many 
            modelBuilder.Entity<Employe>()
                .HasRequired<Projet>(e => e.Projet)
                .WithMany(p => p.Employes)
                .HasForeignKey<int>(e => e.ProjetId)
                //.WillCascadeOnDelete()
                ;
        }

        public System.Data.Entity.DbSet<Course3.Models.Employe> Employes { get; set; }

        public System.Data.Entity.DbSet<Course3.Models.PersonalInfo> PersonalInfoes { get; set; }

        public System.Data.Entity.DbSet<Course3.Models.Projet> Projets { get; set; }
    }
}
