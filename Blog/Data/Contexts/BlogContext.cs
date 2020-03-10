using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Contexts
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
        }
    }
}