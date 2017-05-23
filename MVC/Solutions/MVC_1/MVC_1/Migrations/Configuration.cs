namespace MVC_1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using MVC_1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_1.Models.MyModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC_1.Models.MyModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Products.AddOrUpdate(
                x => x.Name,
                new Product { Name = "Product 1", Description="Description of Product 1", Price = 5.4M},
                new Product { Name = "Product 2", Description = "Description of Product 2", Price = 20M },
                new Product { Name = "Product 3", Description = "Description of Product 3", Price = 0.6M },
                new Product { Name = "Product 4", Description = "Description of Product 4", Price = 250.6M }
            );
            context.SaveChanges();
        }
    }
}
