using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    DbSet<User> Users { get; set; }
    DbSet<Post> Posts { get; set; }

}