namespace MvcWebshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aanbiedings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        aanbiedingsprijs = c.Double(nullable: false),
                        datumVan = c.DateTime(nullable: false),
                        datumTot = c.DateTime(nullable: false),
                        reclametekst = c.String(),
                        product_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.product_id)
                .Index(t => t.product_id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        plaatje = c.String(),
                        naam = c.String(),
                        omschrijving = c.String(),
                        prijs = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        plaatje = c.String(),
                        naam = c.String(),
                        omschrijving = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Klants",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        voornaam = c.String(nullable: false),
                        achternaam = c.String(nullable: false),
                        adres = c.String(nullable: false),
                        postcode = c.String(nullable: false, maxLength: 6),
                        stad = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        klant_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Klants", t => t.klant_id)
                .Index(t => t.klant_id);
            
            CreateTable(
                "dbo.Orderregels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        aantal = c.Int(nullable: false),
                        order_id = c.Int(),
                        product_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Orders", t => t.order_id)
                .ForeignKey("dbo.Products", t => t.product_id)
                .Index(t => t.order_id)
                .Index(t => t.product_id);
            
            CreateTable(
                "dbo.CategorieProducts",
                c => new
                    {
                        Categorie_id = c.Int(nullable: false),
                        Product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Categorie_id, t.Product_id })
                .ForeignKey("dbo.Categories", t => t.Categorie_id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.Categorie_id)
                .Index(t => t.Product_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orderregels", "product_id", "dbo.Products");
            DropForeignKey("dbo.Orderregels", "order_id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "klant_id", "dbo.Klants");
            DropForeignKey("dbo.CategorieProducts", "Product_id", "dbo.Products");
            DropForeignKey("dbo.CategorieProducts", "Categorie_id", "dbo.Categories");
            DropForeignKey("dbo.Aanbiedings", "product_id", "dbo.Products");
            DropIndex("dbo.CategorieProducts", new[] { "Product_id" });
            DropIndex("dbo.CategorieProducts", new[] { "Categorie_id" });
            DropIndex("dbo.Orderregels", new[] { "product_id" });
            DropIndex("dbo.Orderregels", new[] { "order_id" });
            DropIndex("dbo.Orders", new[] { "klant_id" });
            DropIndex("dbo.Aanbiedings", new[] { "product_id" });
            DropTable("dbo.CategorieProducts");
            DropTable("dbo.Orderregels");
            DropTable("dbo.Orders");
            DropTable("dbo.Klants");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Aanbiedings");
        }
    }
}
