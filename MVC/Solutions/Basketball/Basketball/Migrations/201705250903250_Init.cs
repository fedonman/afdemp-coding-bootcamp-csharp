namespace Basketball.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
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
                        Name = c.String(),
                        Password = c.String(),
                        TeamName = c.String(maxLength: 128),
                        Team_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.Teams", t => t.TeamName)
                .ForeignKey("dbo.Teams", t => t.Team_Name)
                .Index(t => t.TeamName)
                .Index(t => t.Team_Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Team_Name", "dbo.Teams");
            DropForeignKey("dbo.Teams", "CreatorEmail", "dbo.Users");
            DropForeignKey("dbo.Users", "TeamName", "dbo.Teams");
            DropIndex("dbo.Users", new[] { "Team_Name" });
            DropIndex("dbo.Users", new[] { "TeamName" });
            DropIndex("dbo.Teams", new[] { "CreatorEmail" });
            DropTable("dbo.Users");
            DropTable("dbo.Teams");
        }
    }
}
