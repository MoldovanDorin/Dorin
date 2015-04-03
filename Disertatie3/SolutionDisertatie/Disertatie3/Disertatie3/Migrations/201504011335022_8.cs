namespace DisertatieModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RawMaterials", "Recipes_Id", "dbo.Recipes");
            DropForeignKey("dbo.StockMaterials", "Materii_Id", "dbo.RawMaterials");
            DropForeignKey("dbo.Recipes", "Produse_Id", "dbo.Products");
            DropForeignKey("dbo.Recipes", "Materii_Id", "dbo.RawMaterials");
            DropForeignKey("dbo.Recipes", "RawMaterials_Id", "dbo.RawMaterials");
            DropForeignKey("dbo.Products", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.StockProducts", "Produse_Id", "dbo.Products");
            DropIndex("dbo.RawMaterials", new[] { "Recipes_Id" });
            DropIndex("dbo.StockMaterials", new[] { "Materii_Id" });
            DropIndex("dbo.Recipes", new[] { "Produse_Id" });
            DropIndex("dbo.Recipes", new[] { "Materii_Id" });
            DropIndex("dbo.Recipes", new[] { "RawMaterials_Id" });
            DropIndex("dbo.Products", new[] { "UserId" });
            DropIndex("dbo.StockProducts", new[] { "Produse_Id" });
            CreateTable(
                "dbo.RecipesMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantitate = c.Int(nullable: false),
                        Recipes_Id = c.Int(),
                        RawMaterials_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipes_Id)
                .ForeignKey("dbo.RawMaterials", t => t.RawMaterials_Id)
                .Index(t => t.Recipes_Id)
                .Index(t => t.RawMaterials_Id);
            
            CreateTable(
                "dbo.AmountOfProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantitate = c.Int(nullable: false),
                        StockProducts_Id = c.Int(),
                        Recipes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StockProducts", t => t.StockProducts_Id)
                .ForeignKey("dbo.Recipes", t => t.Recipes_Id)
                .Index(t => t.StockProducts_Id)
                .Index(t => t.Recipes_Id);
            
            CreateTable(
                "dbo.AmountOfMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantitate = c.Int(nullable: false),
                        rawMaterials_Id = c.Int(),
                        stockMaterials_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RawMaterials", t => t.rawMaterials_Id)
                .ForeignKey("dbo.StockMaterials", t => t.stockMaterials_Id)
                .Index(t => t.rawMaterials_Id)
                .Index(t => t.stockMaterials_Id);
            
            AddColumn("dbo.Recipes", "Nume", c => c.String());
            DropColumn("dbo.RawMaterials", "Recipes_Id");
            DropColumn("dbo.StockMaterials", "MaterieId");
            DropColumn("dbo.StockMaterials", "Cantitate");
            DropColumn("dbo.StockMaterials", "Materii_Id");
            DropColumn("dbo.Recipes", "ProdusId");
            DropColumn("dbo.Recipes", "MaterieId");
            DropColumn("dbo.Recipes", "Cantitate");
            DropColumn("dbo.Recipes", "Produse_Id");
            DropColumn("dbo.Recipes", "Materii_Id");
            DropColumn("dbo.Recipes", "RawMaterials_Id");
            DropColumn("dbo.StockProducts", "ProdusId");
            DropColumn("dbo.StockProducts", "Cantitate");
            DropColumn("dbo.StockProducts", "Produse_Id");
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StockProducts", "Produse_Id", c => c.Int());
            AddColumn("dbo.StockProducts", "Cantitate", c => c.Int(nullable: false));
            AddColumn("dbo.StockProducts", "ProdusId", c => c.Int());
            AddColumn("dbo.Recipes", "RawMaterials_Id", c => c.Int());
            AddColumn("dbo.Recipes", "Materii_Id", c => c.Int());
            AddColumn("dbo.Recipes", "Produse_Id", c => c.Int());
            AddColumn("dbo.Recipes", "Cantitate", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "MaterieId", c => c.Int());
            AddColumn("dbo.Recipes", "ProdusId", c => c.Int());
            AddColumn("dbo.StockMaterials", "Materii_Id", c => c.Int());
            AddColumn("dbo.StockMaterials", "Cantitate", c => c.Int(nullable: false));
            AddColumn("dbo.StockMaterials", "MaterieId", c => c.Int());
            AddColumn("dbo.RawMaterials", "Recipes_Id", c => c.Int());
            DropIndex("dbo.AmountOfMaterials", new[] { "stockMaterials_Id" });
            DropIndex("dbo.AmountOfMaterials", new[] { "rawMaterials_Id" });
            DropIndex("dbo.AmountOfProducts", new[] { "Recipes_Id" });
            DropIndex("dbo.AmountOfProducts", new[] { "StockProducts_Id" });
            DropIndex("dbo.RecipesMaterials", new[] { "RawMaterials_Id" });
            DropIndex("dbo.RecipesMaterials", new[] { "Recipes_Id" });
            DropForeignKey("dbo.AmountOfMaterials", "stockMaterials_Id", "dbo.StockMaterials");
            DropForeignKey("dbo.AmountOfMaterials", "rawMaterials_Id", "dbo.RawMaterials");
            DropForeignKey("dbo.AmountOfProducts", "Recipes_Id", "dbo.Recipes");
            DropForeignKey("dbo.AmountOfProducts", "StockProducts_Id", "dbo.StockProducts");
            DropForeignKey("dbo.RecipesMaterials", "RawMaterials_Id", "dbo.RawMaterials");
            DropForeignKey("dbo.RecipesMaterials", "Recipes_Id", "dbo.Recipes");
            DropColumn("dbo.Recipes", "Nume");
            DropTable("dbo.AmountOfMaterials");
            DropTable("dbo.AmountOfProducts");
            DropTable("dbo.RecipesMaterials");
            CreateIndex("dbo.StockProducts", "Produse_Id");
            CreateIndex("dbo.Products", "UserId");
            CreateIndex("dbo.Recipes", "RawMaterials_Id");
            CreateIndex("dbo.Recipes", "Materii_Id");
            CreateIndex("dbo.Recipes", "Produse_Id");
            CreateIndex("dbo.StockMaterials", "Materii_Id");
            CreateIndex("dbo.RawMaterials", "Recipes_Id");
            AddForeignKey("dbo.StockProducts", "Produse_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Products", "UserId", "dbo.UserProfile", "UserId");
            AddForeignKey("dbo.Recipes", "RawMaterials_Id", "dbo.RawMaterials", "Id");
            AddForeignKey("dbo.Recipes", "Materii_Id", "dbo.RawMaterials", "Id");
            AddForeignKey("dbo.Recipes", "Produse_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.StockMaterials", "Materii_Id", "dbo.RawMaterials", "Id");
            AddForeignKey("dbo.RawMaterials", "Recipes_Id", "dbo.Recipes", "Id");
        }
    }
}
