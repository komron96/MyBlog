using Microsoft.EntityFrameworkCore;
namespace DataAccess;

public interface IUserRepository
{
    public ValueTask<User> CreateUserAsync(User user, CancellationToken token);
    public ValueTask<IEnumerable<User>> GetAllUsers(CancellationToken token);
}


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
        await _appDbContext.SaveChangesAsync();
        return user;
    }

    public async ValueTask<IEnumerable<User>> GetAllUsers(CancellationToken token)
    {
        return await _appDbContext.Users.ToListAsync(token);
    }
}