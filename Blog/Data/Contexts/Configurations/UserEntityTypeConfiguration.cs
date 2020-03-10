using System.Collections.Generic;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Blog.Data.Contexts.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(prop => prop.FirstName).HasColumnName("first_name").HasMaxLength(50).IsRequired();
            builder.Property(prop => prop.LastName).HasColumnName("last_name").HasMaxLength(20).IsRequired();
            builder.Property(prop => prop.Posts).HasColumnName("posts").HasConversion(
                posts =>
                    JsonConvert.SerializeObject(posts,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}),
                posts => JsonConvert.DeserializeObject<List<Post>>(posts,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}));
        }
    }
}