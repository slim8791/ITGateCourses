namespace Course3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManytoMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Formations",
                c => new
                    {
                        FormationId = c.Int(nullable: false, identity: true),
                        Intitule = c.String(),
                        DateDebut = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FormationId);
            
            CreateTable(
                "dbo.FormationEmployes",
                c => new
                    {
                        Formation_FormationId = c.Int(nullable: false),
                        Employe_EmployeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Formation_FormationId, t.Employe_EmployeId })
                .ForeignKey("dbo.Formations", t => t.Formation_FormationId, cascadeDelete: true)
                .ForeignKey("dbo.Employes", t => t.Employe_EmployeId, cascadeDelete: true)
                .Index(t => t.Formation_FormationId)
                .Index(t => t.Employe_EmployeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FormationEmployes", "Employe_EmployeId", "dbo.Employes");
            DropForeignKey("dbo.FormationEmployes", "Formation_FormationId", "dbo.Formations");
            DropIndex("dbo.FormationEmployes", new[] { "Employe_EmployeId" });
            DropIndex("dbo.FormationEmployes", new[] { "Formation_FormationId" });
            DropTable("dbo.FormationEmployes");
            DropTable("dbo.Formations");
        }
    }
}
