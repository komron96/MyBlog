using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic;

public interface IAppDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Post> Posts { get; set; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}


public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

}
