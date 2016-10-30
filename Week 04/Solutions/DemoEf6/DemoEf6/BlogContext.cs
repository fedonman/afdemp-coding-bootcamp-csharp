using System;
using System.Data.Entity;
using DemoEf6.Model;

namespace DemoEf6
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base ("BlogContextConStringName")
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        //To access the fluent API you override the OnModelCreating method in DbContext
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {

        }
    }
}
