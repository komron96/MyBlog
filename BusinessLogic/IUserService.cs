using DataAccess;
namespace BusinessLogic;

public interface IUserService
{
    Task<User> CreateUserAsync(User user, CancellationToken token);
    Task<IEnumerable<User>> GetAllUsers(CancellationToken token);
    Task<bool> FollowUserAsync(long followerId, long followingId, CancellationToken token);
}

public sealed class UserService : IUserService
{
    private readonly IUserRepository _iUserRepository;

    public UserService(IUserRepository iUserRepository)
    {
        _iUserRepository = iUserRepository;
    }

    public async Task<User> CreateUserAsync(User user, CancellationToken token)
    {
        return await _iUserRepository.CreateUserAsync(user, token);
    }

    public async Task<IEnumerable<User>> GetAllUsers(CancellationToken token)
    {
        return await _iUserRepository.GetAllUsers(token);
    }

    public async Task<bool> FollowUserAsync(long followerId, long followingId, CancellationToken token)
    {
        return await _iUserRepository.FollowUserAsync(followerId, followingId, token);
    }
}