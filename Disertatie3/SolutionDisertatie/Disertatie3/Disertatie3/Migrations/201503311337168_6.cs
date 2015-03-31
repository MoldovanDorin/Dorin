namespace DisertatieModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "UpdatedBy", c => c.Int());
            AddColumn("dbo.Payments", "Platit", c => c.Boolean(nullable: false));
            AddColumn("dbo.Payments", "UpdatedBy", c => c.Int());
            AddColumn("dbo.Collections", "UpdatedBy", c => c.Int());
            DropColumn("dbo.Payments", "Plata");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "Plata", c => c.Boolean(nullable: false));
            DropColumn("dbo.Collections", "UpdatedBy");
            DropColumn("dbo.Payments", "UpdatedBy");
            DropColumn("dbo.Payments", "Platit");
            DropColumn("dbo.Recipes", "UpdatedBy");
        }
    }
}
