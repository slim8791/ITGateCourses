namespace Course3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        EmployeId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                        PersonalIfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeId)
                .ForeignKey("dbo.PersonalInfoes", t => t.PersonalIfoId, cascadeDelete: true)
                .Index(t => t.PersonalIfoId);
            
            CreateTable(
                "dbo.PersonalInfoes",
                c => new
                    {
                        PersonalInfoId = c.Int(nullable: false, identity: true),
                        Adresse = c.String(),
                        Phone = c.String(),
                        Matricule = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonalInfoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employes", "PersonalIfoId", "dbo.PersonalInfoes");
            DropIndex("dbo.Employes", new[] { "PersonalIfoId" });
            DropTable("dbo.PersonalInfoes");
            DropTable("dbo.Employes");
        }
    }
}
