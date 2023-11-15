using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> modelBuilder)
    {
        modelBuilder.HasKey(p => p.Id);
        modelBuilder.Property(p => p.Id).HasColumnType("SERIAL").HasColumnName("id").IsRequired();
        modelBuilder.Property(p => p.FirstName).HasColumnType("VARCHAR(20)").HasColumnName("title").IsRequired();
        modelBuilder.Property(p => p.LastName).HasColumnType("VARCHAR(20)").HasColumnName("content").IsRequired();
        modelBuilder.Property(p => p.Email).HasColumnType("VARCHAR(20)").HasColumnName("created_at");
        modelBuilder.Property(p => p.RegDate).HasColumnType("VARCHAR(20)").HasColumnName("likes").IsRequired();
    }
}
