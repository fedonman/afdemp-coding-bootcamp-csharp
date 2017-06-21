namespace TodoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeddescription : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tasks", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Description", c => c.String());
        }
    }
}
