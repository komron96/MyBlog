using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess;

public sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> modelBuilder)
    {
        modelBuilder.ToTable("comments");
        modelBuilder.HasKey(p => p.Id).HasName("pk_comment_id"); ;
        modelBuilder.Property(p => p.Id).UseIdentityColumn().HasColumnName("id").IsRequired();
        modelBuilder.Property(p => p.Text).HasColumnType("VARCHAR(255)").HasColumnName("text").IsRequired(); ;
        modelBuilder.Property(p => p.CreatedAt).HasColumnType("VARCHAR(20)").HasColumnName("created_at").IsRequired();

        modelBuilder
            .HasOne(p => p.Post)
            .WithMany(u => u.Comments)
            .HasForeignKey(p => p.PostId)
            .HasConstraintName("post_id")
            .IsRequired();
            

        modelBuilder
            .HasOne(p => p.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(p => p.UserId)
            .HasConstraintName("user_id")
            .IsRequired();
    }
}
