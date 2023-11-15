using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess;

public sealed class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> modelBuilder)
    {
        modelBuilder.HasKey(p => p.Id).HasName("pk_id");;
        modelBuilder.Property(p => p.Id).HasColumnType("SERIAL").HasColumnName("id").IsRequired();
        modelBuilder.Property(p => p.Title).HasColumnType("VARCHAR(20)").HasColumnName("title");
        modelBuilder.Property(p => p.Content).HasColumnType("VARCHAR(255)").HasColumnName("content").IsRequired();
        modelBuilder.Property(p => p.CreatedAt).HasColumnType("TIMESTAMP").HasColumnName("created_at").IsRequired();
        modelBuilder.Property(p => p.Likes).HasColumnType("INT").HasColumnName("likes").IsRequired();
        modelBuilder.Property(p => p.Visibility).HasColumnType("VARCHAR(20)").HasColumnName("visibillity");

        modelBuilder
            .HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId)
            .IsRequired();

        modelBuilder
            .HasMany(p => p.Comments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId);
    }
}
