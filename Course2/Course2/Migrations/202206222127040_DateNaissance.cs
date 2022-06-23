namespace Course2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateNaissance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employes", "DateNaissance", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employes", "DateNaissance");
        }
    }
}
