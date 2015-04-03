namespace DisertatieModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RawMaterials", "Recipes_Id", c => c.Int());
            AddColumn("dbo.Recipes", "RawMaterials_Id", c => c.Int());
            AddForeignKey("dbo.RawMaterials", "Recipes_Id", "dbo.Recipes", "Id");
            AddForeignKey("dbo.Recipes", "RawMaterials_Id", "dbo.RawMaterials", "Id");
            CreateIndex("dbo.RawMaterials", "Recipes_Id");
            CreateIndex("dbo.Recipes", "RawMaterials_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Recipes", new[] { "RawMaterials_Id" });
            DropIndex("dbo.RawMaterials", new[] { "Recipes_Id" });
            DropForeignKey("dbo.Recipes", "RawMaterials_Id", "dbo.RawMaterials");
            DropForeignKey("dbo.RawMaterials", "Recipes_Id", "dbo.Recipes");
            DropColumn("dbo.Recipes", "RawMaterials_Id");
            DropColumn("dbo.RawMaterials", "Recipes_Id");
        }
    }
}
