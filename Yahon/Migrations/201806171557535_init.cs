namespace Yahon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        BrandName = c.String(nullable: false),
                        BrandImage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductPrice = c.Int(nullable: false),
                        ProductDetail = c.String(nullable: false),
                        ProductImage = c.String(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.PurchaseProducts",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        PurchaseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.PurchaseID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.PurchaseID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Password = c.String(nullable: false),
                        Salt = c.Binary(),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PurchaseID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.CustomerSessions",
                c => new
                    {
                        EmailId = c.String(nullable: false, maxLength: 128),
                        PasswordHash = c.String(nullable: false),
                        RememberMe = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseProducts", "PurchaseID", "dbo.Purchases");
            DropForeignKey("dbo.Purchases", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.PurchaseProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Purchases", new[] { "CustomerID" });
            DropIndex("dbo.PurchaseProducts", new[] { "PurchaseID" });
            DropIndex("dbo.PurchaseProducts", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropTable("dbo.CustomerSessions");
            DropTable("dbo.Purchases");
            DropTable("dbo.Customers");
            DropTable("dbo.PurchaseProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
        }
    }
}
