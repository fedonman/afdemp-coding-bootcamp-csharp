namespace Skroutz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Attributes", newName: "AttributeValues");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AttributeValues", newName: "Attributes");
        }
    }
}
