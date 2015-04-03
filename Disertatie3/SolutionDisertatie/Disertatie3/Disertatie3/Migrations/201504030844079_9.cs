namespace DisertatieModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AmountOfProducts", "StockProducts_Id", "dbo.StockProducts");
            DropForeignKey("dbo.AmountOfProducts", "Recipes_Id", "dbo.Recipes");
            DropIndex("dbo.AmountOfProducts", new[] { "StockProducts_Id" });
            DropIndex("dbo.AmountOfProducts", new[] { "Recipes_Id" });
            AlterColumn("dbo.AmountOfProducts", "stockProducts_Id", c => c.Int());
            AlterColumn("dbo.AmountOfProducts", "recipes_Id", c => c.Int());
            AddForeignKey("dbo.AmountOfProducts", "recipes_Id", "dbo.Recipes", "Id");
            AddForeignKey("dbo.AmountOfProducts", "stockProducts_Id", "dbo.StockProducts", "Id");
            CreateIndex("dbo.AmountOfProducts", "recipes_Id");
            CreateIndex("dbo.AmountOfProducts", "stockProducts_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AmountOfProducts", new[] { "stockProducts_Id" });
            DropIndex("dbo.AmountOfProducts", new[] { "recipes_Id" });
            DropForeignKey("dbo.AmountOfProducts", "stockProducts_Id", "dbo.StockProducts");
            DropForeignKey("dbo.AmountOfProducts", "recipes_Id", "dbo.Recipes");
            AlterColumn("dbo.AmountOfProducts", "Recipes_Id", c => c.Int());
            AlterColumn("dbo.AmountOfProducts", "StockProducts_Id", c => c.Int());
            CreateIndex("dbo.AmountOfProducts", "Recipes_Id");
            CreateIndex("dbo.AmountOfProducts", "StockProducts_Id");
            AddForeignKey("dbo.AmountOfProducts", "Recipes_Id", "dbo.Recipes", "Id");
            AddForeignKey("dbo.AmountOfProducts", "StockProducts_Id", "dbo.StockProducts", "Id");
        }
    }
}
