using BlogApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Infrastructure.Context
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<CategoryPost> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryPost>(entity =>
            {
                entity.HasKey(x => x.Id);
                
                entity.Property(x => x.Title);
                entity.Property(x => x.Active);
                entity.Property(x => x.Path);

                entity.HasOne(x => x.Parent)
                    .WithMany(x => x.Children)
                    .HasForeignKey(x => x.ParentId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
