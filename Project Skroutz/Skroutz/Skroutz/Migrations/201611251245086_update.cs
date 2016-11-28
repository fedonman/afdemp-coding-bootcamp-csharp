namespace Skroutz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.ProductId, t.StoreId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Web = c.String(),
                        Headquarters = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Products", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Description", c => c.String());
            DropForeignKey("dbo.Inventories", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Inventories", "ProductId", "dbo.Products");
            DropIndex("dbo.Inventories", new[] { "StoreId" });
            DropIndex("dbo.Inventories", new[] { "ProductId" });
            DropTable("dbo.Stores");
            DropTable("dbo.Inventories");
        }
    }
}
