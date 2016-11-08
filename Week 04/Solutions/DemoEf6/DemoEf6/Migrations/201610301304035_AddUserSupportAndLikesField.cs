namespace DemoEf6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserSupportAndLikesField : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "Content", c => c.String());
            AddColumn("dbo.Posts", "Likes", c => c.Int());
            AddColumn("dbo.Posts", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "Title", c => c.String(maxLength: 400));
            CreateIndex("dbo.Posts", "UserId");
            AddForeignKey("dbo.Posts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "UserId" });
            AlterColumn("dbo.Posts", "Title", c => c.String());
            DropColumn("dbo.Posts", "UserId");
            DropColumn("dbo.Posts", "Likes");
            DropColumn("dbo.Posts", "Content");
            DropTable("dbo.Users");
        }
    }
}
