using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Contexts.Configurations
{
    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("post");
            builder.HasKey(prop => prop.Id);
            builder.HasOne(p => p.User)
                   .WithMany()
                   .HasForeignKey(p => p.UserId);
            builder.Property(prop => prop.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(prop => prop.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(prop => prop.Content).HasColumnName("content").IsRequired();
        }
    }
}