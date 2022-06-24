namespace Course3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProjetEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projets",
                c => new
                    {
                        ProjetId = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProjetId);
            
            AddColumn("dbo.Employes", "ProjetId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employes", "ProjetId");
            AddForeignKey("dbo.Employes", "ProjetId", "dbo.Projets", "ProjetId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employes", "ProjetId", "dbo.Projets");
            DropIndex("dbo.Employes", new[] { "ProjetId" });
            DropColumn("dbo.Employes", "ProjetId");
            DropTable("dbo.Projets");
        }
    }
}
