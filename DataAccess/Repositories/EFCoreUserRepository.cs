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


    public async Task<(User, User)> FollowUserAsync(long followerId, long followingId, CancellationToken token)
    {
        var follower = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == followerId);
        var following = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == followingId);

        if (follower != null && following != null)
        {
            return (follower, following);
        }
        else { return (null, null); }

    }

}