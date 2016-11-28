namespace Skroutz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attributes",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        AttributeKeyId = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => new { t.ProductId, t.AttributeKeyId })
                .ForeignKey("dbo.AttributeKeys", t => t.AttributeKeyId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.AttributeKeyId);
            
            CreateTable(
                "dbo.AttributeKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MeasurementUnit = c.String(),
                        DataType = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attributes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Attributes", "AttributeKeyId", "dbo.AttributeKeys");
            DropForeignKey("dbo.AttributeKeys", "CategoryId", "dbo.Categories");
            DropIndex("dbo.AttributeKeys", new[] { "CategoryId" });
            DropIndex("dbo.Attributes", new[] { "AttributeKeyId" });
            DropIndex("dbo.Attributes", new[] { "ProductId" });
            DropTable("dbo.AttributeKeys");
            DropTable("dbo.Attributes");
        }
    }
}
