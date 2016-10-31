using System;
using System.Data.Entity;
using DemoEf6.Model;

namespace DemoEf6
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base ("ConnectionName")
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        //To access the fluent API you override the OnModelCreating method in DbContext
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {

        }
    }
}
