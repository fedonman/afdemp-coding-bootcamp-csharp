namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Blog : DbContext
    {
        public Blog()
            : base("name=Blog1")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Posts)
                .WithOptional(e => e.Categories)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Posts>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Posts>()
                .Property(e => e.Content)
                .IsUnicode(false);
        }
    }
}
