namespace DisertatieEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Incasaris", "UserId", "dbo.UserProfile");
            DropIndex("dbo.Incasaris", new[] { "UserId" });
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Incasat = c.Boolean(nullable: false),
                        DeLa = c.String(),
                        Data = c.DateTime(nullable: false),
                        FacturaInc = c.String(),
                        DocumentInc = c.String(),
                        ValoareInc = c.Int(nullable: false),
                        Scadenta = c.DateTime(nullable: false),
                        Scontare = c.String(),
                        Girat = c.String(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId);
            
            DropTable("dbo.Incasaris");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Incasaris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Incasat = c.Boolean(nullable: false),
                        DeLa = c.String(),
                        Data = c.DateTime(nullable: false),
                        FacturaInc = c.String(),
                        DocumentInc = c.String(),
                        ValoareInc = c.Int(nullable: false),
                        Scadenta = c.DateTime(nullable: false),
                        Scontare = c.String(),
                        Girat = c.String(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.Collections", new[] { "UserId" });
            DropForeignKey("dbo.Collections", "UserId", "dbo.UserProfile");
            DropTable("dbo.Collections");
            CreateIndex("dbo.Incasaris", "UserId");
            AddForeignKey("dbo.Incasaris", "UserId", "dbo.UserProfile", "UserId");
        }
    }
}
