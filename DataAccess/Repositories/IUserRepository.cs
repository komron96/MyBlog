namespace DataAccess;

public interface IUserRepository
{
    public ValueTask<User> CreateUserAsync(User user, CancellationToken token = default);
    public ValueTask<IEnumerable<User>> GetAllUsers(CancellationToken token = default);
    public Task<(User, User)> FollowUserAsync(long followerId, long followingId, CancellationToken token = default);
    public Task<bool> DeleteUserAsync(long userId, CancellationToken token = default);
}
