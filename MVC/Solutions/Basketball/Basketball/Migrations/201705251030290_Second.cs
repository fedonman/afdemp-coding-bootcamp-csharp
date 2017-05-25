namespace Basketball.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JoinRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 128),
                        TeamName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamName)
                .ForeignKey("dbo.Users", t => t.UserName)
                .Index(t => t.UserName)
                .Index(t => t.TeamName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JoinRequests", "UserName", "dbo.Users");
            DropForeignKey("dbo.JoinRequests", "TeamName", "dbo.Teams");
            DropIndex("dbo.JoinRequests", new[] { "TeamName" });
            DropIndex("dbo.JoinRequests", new[] { "UserName" });
            DropTable("dbo.JoinRequests");
        }
    }
}
