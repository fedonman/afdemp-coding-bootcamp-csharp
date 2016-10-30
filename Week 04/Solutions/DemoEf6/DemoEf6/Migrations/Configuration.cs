using DemoEf6.Model;

namespace DemoEf6.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DemoEf6.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DemoEf6.BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Blogs.AddOrUpdate(
              b => b.Title,
              new Blog() { Title = "My Ef Blog" },
              new Blog() { Title = "My .Net Blog" }
            );


            context.Users.AddOrUpdate(
              b => b.UserName,
              new User() { UserName = "mpapadakis", FullName = "Michalis Papadakis", Email = "mpapadakis@egritosgroup.gr" },
              new User() { UserName = "xrkolovos", FullName = "Chrysostomos Kolovos", Email = "xrkolovos@egritosgroup.gr" }
            );

            context.SaveChanges();

            var papadId = context.Users.FirstOrDefault(x => x.FullName == "Michalis Papadakis").Id;
            var xrklvId = context.Users.FirstOrDefault(x => x.FullName == "Michalis Papadakis").Id;
            var blog = context.Blogs.AsNoTracking().FirstOrDefault(x => x.Title == "My Ef Blog");


            context.Posts.AddOrUpdate(p => new { p.Title, p.UserId },
              new Post() { Title = "Post One", Content = "Post One Content", Likes = 45, UserId = papadId, BlogId = blog.Id },
              new Post() { Title = "Post Two", Content = "Post Two Content", Likes = 1234, UserId = papadId, BlogId = blog.Id },
              new Post() { Title = "Post Three", Content = "Post Three Content", Likes = 154, UserId = xrklvId, BlogId = blog.Id },
              new Post() { Title = "Post Four", Content = "Post Four Content", Likes = 22, UserId = papadId, BlogId = blog.Id }
            );
            
            context.SaveChanges();
        }
    }
}
