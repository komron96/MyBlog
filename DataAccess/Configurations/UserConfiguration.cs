using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> modelBuilder)
    {
        modelBuilder.HasKey(p => p.Id).HasName("pk_id");
        modelBuilder.Property(p => p.Id).HasColumnType("SERIAL").HasColumnName("id").IsRequired();
        modelBuilder.Property(p => p.FirstName).HasColumnType("VARCHAR(20)").HasColumnName("first_name").IsRequired();
        modelBuilder.Property(p => p.LastName).HasColumnType("VARCHAR(20)").HasColumnName("last_name").IsRequired();
        modelBuilder.Property(p => p.Email).HasColumnType("VARCHAR(20)").HasColumnName("email");
        modelBuilder.Property(p => p.RegDate).HasColumnType("TIMESTAMP").HasColumnName("reg_date").IsRequired();

        modelBuilder
            .HasMany(f => f.Followers)
            .WithMany(f => f.Following)
            .UsingEntity(f => f.ToTable("user_followers"));

        modelBuilder
            .HasMany(u => u.Posts)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        modelBuilder
            .HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId);

    }
}
