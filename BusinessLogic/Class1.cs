using DataAccess;
namespace BusinessLogic;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    DbSet<User> Users { get; set; }
    DbSet<Post> Posts { get; set; }

}