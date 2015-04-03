namespace DisertatieModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipesMaterials", "Recipes_Id", "dbo.Recipes");
            DropForeignKey("dbo.RecipesMaterials", "RawMaterials_Id", "dbo.RawMaterials");
            DropForeignKey("dbo.AmountOfProducts", "recipes_Id", "dbo.Recipes");
            DropForeignKey("dbo.AmountOfProducts", "stockProducts_Id", "dbo.StockProducts");
            DropForeignKey("dbo.AmountOfMaterials", "rawMaterials_Id", "dbo.RawMaterials");
            DropForeignKey("dbo.AmountOfMaterials", "stockMaterials_Id", "dbo.StockMaterials");
            DropIndex("dbo.RecipesMaterials", new[] { "Recipes_Id" });
            DropIndex("dbo.RecipesMaterials", new[] { "RawMaterials_Id" });
            DropIndex("dbo.AmountOfProducts", new[] { "recipes_Id" });
            DropIndex("dbo.AmountOfProducts", new[] { "stockProducts_Id" });
            DropIndex("dbo.AmountOfMaterials", new[] { "rawMaterials_Id" });
            DropIndex("dbo.AmountOfMaterials", new[] { "stockMaterials_Id" });
            RenameColumn(table: "dbo.RecipesMaterials", name: "Recipes_Id", newName: "RecipesId");
            RenameColumn(table: "dbo.RecipesMaterials", name: "RawMaterials_Id", newName: "RawMaterialsId");
            RenameColumn(table: "dbo.AmountOfProducts", name: "recipes_Id", newName: "RecipesId");
            RenameColumn(table: "dbo.AmountOfProducts", name: "stockProducts_Id", newName: "StockProductsId");
            RenameColumn(table: "dbo.AmountOfMaterials", name: "rawMaterials_Id", newName: "RawMaterialsId");
            RenameColumn(table: "dbo.AmountOfMaterials", name: "stockMaterials_Id", newName: "StockMaterialsId");
            AddForeignKey("dbo.RecipesMaterials", "RecipesId", "dbo.Recipes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RecipesMaterials", "RawMaterialsId", "dbo.RawMaterials", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AmountOfProducts", "RecipesId", "dbo.Recipes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AmountOfProducts", "StockProductsId", "dbo.StockProducts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AmountOfMaterials", "RawMaterialsId", "dbo.RawMaterials", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AmountOfMaterials", "StockMaterialsId", "dbo.StockMaterials", "Id", cascadeDelete: true);
            CreateIndex("dbo.RecipesMaterials", "RecipesId");
            CreateIndex("dbo.RecipesMaterials", "RawMaterialsId");
            CreateIndex("dbo.AmountOfProducts", "RecipesId");
            CreateIndex("dbo.AmountOfProducts", "StockProductsId");
            CreateIndex("dbo.AmountOfMaterials", "RawMaterialsId");
            CreateIndex("dbo.AmountOfMaterials", "StockMaterialsId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AmountOfMaterials", new[] { "StockMaterialsId" });
            DropIndex("dbo.AmountOfMaterials", new[] { "RawMaterialsId" });
            DropIndex("dbo.AmountOfProducts", new[] { "StockProductsId" });
            DropIndex("dbo.AmountOfProducts", new[] { "RecipesId" });
            DropIndex("dbo.RecipesMaterials", new[] { "RawMaterialsId" });
            DropIndex("dbo.RecipesMaterials", new[] { "RecipesId" });
            DropForeignKey("dbo.AmountOfMaterials", "StockMaterialsId", "dbo.StockMaterials");
            DropForeignKey("dbo.AmountOfMaterials", "RawMaterialsId", "dbo.RawMaterials");
            DropForeignKey("dbo.AmountOfProducts", "StockProductsId", "dbo.StockProducts");
            DropForeignKey("dbo.AmountOfProducts", "RecipesId", "dbo.Recipes");
            DropForeignKey("dbo.RecipesMaterials", "RawMaterialsId", "dbo.RawMaterials");
            DropForeignKey("dbo.RecipesMaterials", "RecipesId", "dbo.Recipes");
            RenameColumn(table: "dbo.AmountOfMaterials", name: "StockMaterialsId", newName: "stockMaterials_Id");
            RenameColumn(table: "dbo.AmountOfMaterials", name: "RawMaterialsId", newName: "rawMaterials_Id");
            RenameColumn(table: "dbo.AmountOfProducts", name: "StockProductsId", newName: "stockProducts_Id");
            RenameColumn(table: "dbo.AmountOfProducts", name: "RecipesId", newName: "recipes_Id");
            RenameColumn(table: "dbo.RecipesMaterials", name: "RawMaterialsId", newName: "RawMaterials_Id");
            RenameColumn(table: "dbo.RecipesMaterials", name: "RecipesId", newName: "Recipes_Id");
            CreateIndex("dbo.AmountOfMaterials", "stockMaterials_Id");
            CreateIndex("dbo.AmountOfMaterials", "rawMaterials_Id");
            CreateIndex("dbo.AmountOfProducts", "stockProducts_Id");
            CreateIndex("dbo.AmountOfProducts", "recipes_Id");
            CreateIndex("dbo.RecipesMaterials", "RawMaterials_Id");
            CreateIndex("dbo.RecipesMaterials", "Recipes_Id");
            AddForeignKey("dbo.AmountOfMaterials", "stockMaterials_Id", "dbo.StockMaterials", "Id");
            AddForeignKey("dbo.AmountOfMaterials", "rawMaterials_Id", "dbo.RawMaterials", "Id");
            AddForeignKey("dbo.AmountOfProducts", "stockProducts_Id", "dbo.StockProducts", "Id");
            AddForeignKey("dbo.AmountOfProducts", "recipes_Id", "dbo.Recipes", "Id");
            AddForeignKey("dbo.RecipesMaterials", "RawMaterials_Id", "dbo.RawMaterials", "Id");
            AddForeignKey("dbo.RecipesMaterials", "Recipes_Id", "dbo.Recipes", "Id");
        }
    }
}
