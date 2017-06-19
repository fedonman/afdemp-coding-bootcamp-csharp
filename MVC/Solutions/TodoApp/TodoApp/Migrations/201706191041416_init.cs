namespace TodoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        IsCompleted = c.Boolean(nullable: false),
                        UserEmail = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserEmail)
                .Index(t => t.UserEmail);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Salt = c.String(),
                        HashedPasswordAndSalt = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "UserEmail", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "UserEmail" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
        }
    }
}
