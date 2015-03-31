namespace DisertatieEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Consums", "Materii_Id", "dbo.MateriiPrimes");
            DropForeignKey("dbo.MateriiPrimes", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.StocMateriis", "Materii_Id", "dbo.MateriiPrimes");
            DropForeignKey("dbo.Retetes", "Materii_Id", "dbo.MateriiPrimes");
            DropIndex("dbo.Consums", new[] { "Materii_Id" });
            DropIndex("dbo.MateriiPrimes", new[] { "UserId" });
            DropIndex("dbo.StocMateriis", new[] { "Materii_Id" });
            DropIndex("dbo.Retetes", new[] { "Materii_Id" });
            CreateTable(
                "dbo.RawMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        UserId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId);
            
            AddForeignKey("dbo.Consums", "Materii_Id", "dbo.RawMaterials", "Id");
            AddForeignKey("dbo.StocMateriis", "Materii_Id", "dbo.RawMaterials", "Id");
            AddForeignKey("dbo.Retetes", "Materii_Id", "dbo.RawMaterials", "Id");
            CreateIndex("dbo.Consums", "Materii_Id");
            CreateIndex("dbo.StocMateriis", "Materii_Id");
            CreateIndex("dbo.Retetes", "Materii_Id");
            DropTable("dbo.MateriiPrimes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MateriiPrimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        UserId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.Retetes", new[] { "Materii_Id" });
            DropIndex("dbo.StocMateriis", new[] { "Materii_Id" });
            DropIndex("dbo.RawMaterials", new[] { "UserId" });
            DropIndex("dbo.Consums", new[] { "Materii_Id" });
            DropForeignKey("dbo.Retetes", "Materii_Id", "dbo.RawMaterials");
            DropForeignKey("dbo.StocMateriis", "Materii_Id", "dbo.RawMaterials");
            DropForeignKey("dbo.RawMaterials", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Consums", "Materii_Id", "dbo.RawMaterials");
            DropTable("dbo.RawMaterials");
            CreateIndex("dbo.Retetes", "Materii_Id");
            CreateIndex("dbo.StocMateriis", "Materii_Id");
            CreateIndex("dbo.MateriiPrimes", "UserId");
            CreateIndex("dbo.Consums", "Materii_Id");
            AddForeignKey("dbo.Retetes", "Materii_Id", "dbo.MateriiPrimes", "Id");
            AddForeignKey("dbo.StocMateriis", "Materii_Id", "dbo.MateriiPrimes", "Id");
            AddForeignKey("dbo.MateriiPrimes", "UserId", "dbo.UserProfile", "UserId");
            AddForeignKey("dbo.Consums", "Materii_Id", "dbo.MateriiPrimes", "Id");
        }
    }
}
