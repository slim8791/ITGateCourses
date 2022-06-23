namespace Course2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMatricule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employes", "Matricule", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employes", "Matricule");
        }
    }
}
