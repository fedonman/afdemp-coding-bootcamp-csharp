namespace Basketball.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        CreatorEmail = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Users", t => t.CreatorEmail)
                .Index(t => t.CreatorEmail);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        TeamName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.Teams", t => t.TeamName)
                .Index(t => t.TeamName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JoinRequests", "UserName", "dbo.Users");
            DropForeignKey("dbo.JoinRequests", "TeamName", "dbo.Teams");
            DropForeignKey("dbo.Teams", "CreatorEmail", "dbo.Users");
            DropForeignKey("dbo.Users", "TeamName", "dbo.Teams");
            DropIndex("dbo.Users", new[] { "TeamName" });
            DropIndex("dbo.Teams", new[] { "CreatorEmail" });
            DropIndex("dbo.JoinRequests", new[] { "TeamName" });
            DropIndex("dbo.JoinRequests", new[] { "UserName" });
            DropTable("dbo.Users");
            DropTable("dbo.Teams");
            DropTable("dbo.JoinRequests");
        }
    }
}
