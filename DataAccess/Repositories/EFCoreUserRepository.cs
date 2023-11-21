using Microsoft.EntityFrameworkCore;
namespace DataAccess;

public sealed class EFCoreUserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public EFCoreUserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async ValueTask<User> CreateUserAsync(User user, CancellationToken token = default)
    {
        await _appDbContext.Users.AddAsync(user, token);
        await _appDbContext.SaveChangesAsync(token);
        return user;
    }

    public async ValueTask<IEnumerable<User>> GetAllUsers(CancellationToken token = default)
    {
        return await _appDbContext.Users.ToListAsync(token);
    }


    public async Task<(User, User)> FollowUserAsync(long followerId, long followingId, CancellationToken token = default)
    {
        User follower = await _appDbContext.Users.FindAsync(followerId);
        User following = await _appDbContext.Users.FindAsync(followingId);

        if (follower != null && following != null)
        {
            return (follower, following);
        }
        else { return (null, null); }
    }

    public async Task<bool> DeleteUserAsync(long userId, CancellationToken token = default)
    {
        User user = await _appDbContext.Users.FindAsync(userId);
        if (user != null)
        {
            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync(token);
            return true;
        }
        else
        {
            return false;
        }
    }
}