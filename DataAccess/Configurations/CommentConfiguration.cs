using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess;

public sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> modelBuilder)
    {
        modelBuilder.HasKey(p => p.Id).HasName("pk_id"); ;
        modelBuilder.Property(p => p.Id).HasColumnType("SERIAL").HasColumnName("id").IsRequired();
        modelBuilder.Property(p => p.Text).HasColumnType("VARCHAR(255)").HasColumnName("text");
        modelBuilder.Property(p => p.CommentedAt).HasColumnType("VARCHAR(20)").HasColumnName("content").IsRequired();

        modelBuilder
            .HasOne(p => p.Post)
            .WithMany(u => u.Comments)
            .HasForeignKey(p => p.PostId)
            .IsRequired();

        modelBuilder
            .HasOne(p => p.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(p => p.UserId)
            .IsRequired();
    }
}
