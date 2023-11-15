using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess;

public sealed class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> modelBuilder)
    {
        modelBuilder.HasKey(p => p.Id);
        modelBuilder.Property(p => p.Id).HasColumnType("SERIAL").HasColumnName("id").IsRequired();
        modelBuilder.Property(p => p.Title).HasColumnType("VARCHAR(20)").HasColumnName("title").IsRequired();
        modelBuilder.Property(p => p.Content).HasColumnType("VARCHAR(20)").HasColumnName("content").IsRequired();
        modelBuilder.Property(p => p.CreatedAt).HasColumnType("VARCHAR(20)").HasColumnName("created_at").IsRequired();
        modelBuilder.Property(p => p.Likes).HasColumnType("VARCHAR(20)").HasColumnName("likes").IsRequired();
        modelBuilder.Property(p => p.Comments).HasColumnType("VARCHAR(20)").HasColumnName("comments");
        modelBuilder.Property(p => p.Visibility).HasColumnType("VARCHAR(20)").HasColumnName("visibillity");
    }
}
