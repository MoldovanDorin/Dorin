namespace DisertatieModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Consums", "Materii_Id", "dbo.RawMaterials");
            DropForeignKey("dbo.Consums", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.StocMateriis", "Materii_Id", "dbo.RawMaterials");
            DropForeignKey("dbo.Retetes", "Produse_Id", "dbo.Produses");
            DropForeignKey("dbo.Retetes", "Materii_Id", "dbo.RawMaterials");
            DropForeignKey("dbo.Retetes", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Produses", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.StocProduses", "Produse_Id", "dbo.Produses");
            DropForeignKey("dbo.Platis", "UserId", "dbo.UserProfile");
            DropIndex("dbo.Consums", new[] { "Materii_Id" });
            DropIndex("dbo.Consums", new[] { "UserId" });
            DropIndex("dbo.StocMateriis", new[] { "Materii_Id" });
            DropIndex("dbo.Retetes", new[] { "Produse_Id" });
            DropIndex("dbo.Retetes", new[] { "Materii_Id" });
            DropIndex("dbo.Retetes", new[] { "UserId" });
            DropIndex("dbo.Produses", new[] { "UserId" });
            DropIndex("dbo.StocProduses", new[] { "Produse_Id" });
            DropIndex("dbo.Platis", new[] { "UserId" });
            CreateTable(
                "dbo.Consumptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        MaterieId = c.Int(),
                        UserId = c.Int(),
                        Cantitate = c.Int(nullable: false),
                        Materii_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RawMaterials", t => t.Materii_Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.Materii_Id)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.StockMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        MaterieId = c.Int(),
                        Cantitate = c.Int(nullable: false),
                        Materii_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RawMaterials", t => t.Materii_Id)
                .Index(t => t.Materii_Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdusId = c.Int(),
                        MaterieId = c.Int(),
                        Cantitate = c.Int(nullable: false),
                        UserId = c.Int(),
                        Produse_Id = c.Int(),
                        Materii_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Produse_Id)
                .ForeignKey("dbo.RawMaterials", t => t.Materii_Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.Produse_Id)
                .Index(t => t.Materii_Id)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.StockProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        ProdusId = c.Int(),
                        Cantitate = c.Int(nullable: false),
                        Produse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Produse_Id)
                .Index(t => t.Produse_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Plata = c.Boolean(nullable: false),
                        Catre = c.String(),
                        DocumentPlata = c.String(),
                        Factura = c.String(),
                        Valoare = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId);
            
            DropTable("dbo.Consums");
            DropTable("dbo.StocMateriis");
            DropTable("dbo.Retetes");
            DropTable("dbo.Produses");
            DropTable("dbo.StocProduses");
            DropTable("dbo.Platis");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Platis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Plata = c.Boolean(nullable: false),
                        Catre = c.String(),
                        DocumentPlata = c.String(),
                        Factura = c.String(),
                        Valoare = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StocProduses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        ProdusId = c.Int(),
                        Cantitate = c.Int(nullable: false),
                        Produse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Retetes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdusId = c.Int(),
                        MaterieId = c.Int(),
                        Cantitate = c.Int(nullable: false),
                        UserId = c.Int(),
                        Produse_Id = c.Int(),
                        Materii_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StocMateriis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        MaterieId = c.Int(),
                        Cantitate = c.Int(nullable: false),
                        Materii_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Consums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        MaterieId = c.Int(),
                        UserId = c.Int(),
                        Cantitate = c.Int(nullable: false),
                        Materii_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.Payments", new[] { "UserId" });
            DropIndex("dbo.StockProducts", new[] { "Produse_Id" });
            DropIndex("dbo.Products", new[] { "UserId" });
            DropIndex("dbo.Recipes", new[] { "UserId" });
            DropIndex("dbo.Recipes", new[] { "Materii_Id" });
            DropIndex("dbo.Recipes", new[] { "Produse_Id" });
            DropIndex("dbo.StockMaterials", new[] { "Materii_Id" });
            DropIndex("dbo.Consumptions", new[] { "UserId" });
            DropIndex("dbo.Consumptions", new[] { "Materii_Id" });
            DropForeignKey("dbo.Payments", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.StockProducts", "Produse_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Recipes", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Recipes", "Materii_Id", "dbo.RawMaterials");
            DropForeignKey("dbo.Recipes", "Produse_Id", "dbo.Products");
            DropForeignKey("dbo.StockMaterials", "Materii_Id", "dbo.RawMaterials");
            DropForeignKey("dbo.Consumptions", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Consumptions", "Materii_Id", "dbo.RawMaterials");
            DropTable("dbo.Payments");
            DropTable("dbo.StockProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Recipes");
            DropTable("dbo.StockMaterials");
            DropTable("dbo.Consumptions");
            CreateIndex("dbo.Platis", "UserId");
            CreateIndex("dbo.StocProduses", "Produse_Id");
            CreateIndex("dbo.Produses", "UserId");
            CreateIndex("dbo.Retetes", "UserId");
            CreateIndex("dbo.Retetes", "Materii_Id");
            CreateIndex("dbo.Retetes", "Produse_Id");
            CreateIndex("dbo.StocMateriis", "Materii_Id");
            CreateIndex("dbo.Consums", "UserId");
            CreateIndex("dbo.Consums", "Materii_Id");
            AddForeignKey("dbo.Platis", "UserId", "dbo.UserProfile", "UserId");
            AddForeignKey("dbo.StocProduses", "Produse_Id", "dbo.Produses", "Id");
            AddForeignKey("dbo.Produses", "UserId", "dbo.UserProfile", "UserId");
            AddForeignKey("dbo.Retetes", "UserId", "dbo.UserProfile", "UserId");
            AddForeignKey("dbo.Retetes", "Materii_Id", "dbo.RawMaterials", "Id");
            AddForeignKey("dbo.Retetes", "Produse_Id", "dbo.Produses", "Id");
            AddForeignKey("dbo.StocMateriis", "Materii_Id", "dbo.RawMaterials", "Id");
            AddForeignKey("dbo.Consums", "UserId", "dbo.UserProfile", "UserId");
            AddForeignKey("dbo.Consums", "Materii_Id", "dbo.RawMaterials", "Id");
        }
    }
}
