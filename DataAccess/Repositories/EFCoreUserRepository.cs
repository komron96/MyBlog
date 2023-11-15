using Microsoft.EntityFrameworkCore;
namespace DataAccess;

public sealed class EFCoreUserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public EFCoreUserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async ValueTask<User> CreateUserAsync(User user, CancellationToken token)
    {
        await _appDbContext.Users.AddAsync(user, token);
        await _appDbContext.SaveChangesAsync(token);
        return user;
    }

    public async ValueTask<IEnumerable<User>> GetAllUsers(CancellationToken token)
    {
        return await _appDbContext.Users.ToListAsync(token);
    }
}