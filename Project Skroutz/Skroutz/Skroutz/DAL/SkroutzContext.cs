namespace Skroutz.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Skroutz.Models;

    public class SkroutzContext : DbContext
    {
        // Your context has been configured to use a 'SkroutzContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Skroutz.DAL.SkroutzContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SkroutzContext' 
        // connection string in the application configuration file.
        public SkroutzContext()
            : base("name=SkroutzContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<AttributeKey> AttributeKeys { get; set; }
        public virtual DbSet<AttributeValue> Attributes { get; set; }
    }

}