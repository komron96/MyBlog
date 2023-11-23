using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess;

public sealed class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> modelBuilder)
    {
        modelBuilder.ToTable("posts");
        modelBuilder.HasKey(p => p.Id).HasName("pk_post_id"); ;
        modelBuilder.Property(p => p.Id).UseIdentityColumn().HasColumnName("id").IsRequired();
        modelBuilder.Property(p => p.Title).HasColumnType("VARCHAR(20)").HasColumnName("title");
        modelBuilder.Property(p => p.Content).HasColumnType("VARCHAR(255)").HasColumnName("content").IsRequired();
        modelBuilder.Property(p => p.CreatedAt).HasColumnType("TIMESTAMP").HasColumnName("created_at").IsRequired(); ;
        modelBuilder.Property(p => p.Likes).HasColumnType("INT").HasColumnName("likes").IsRequired();

        modelBuilder
            .HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId)
            .HasConstraintName("user_id")
            .IsRequired();

        modelBuilder
            .HasMany(p => p.Comments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId)
            .HasConstraintName("comment_id");

    }
}
