using DataAccess;
namespace BusinessLogic;

public interface IUserService
{
    Task<UserDto?> CreateUserAsync(UserDto userDto, CancellationToken token = default);
    Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken token = default);
    Task<(UserDto?, UserDto?)> FollowUserAsync(long followerId, long followingId, CancellationToken token = default);
    Task<bool> DeleteUserAsync(long userId, CancellationToken token = default);
}

public sealed class UserService : IUserService
{
    private readonly IUserRepository _iUserRepository;

    public UserService(IUserRepository iUserRepository)
    {
        _iUserRepository = iUserRepository;
    }

    public async Task<UserDto?> CreateUserAsync(UserDto userDto, CancellationToken token = default)
    {
        User user = await _iUserRepository.CreateUserAsync(userDto.ToUserClass(), token);
        if (user is null)
            return null;
        return user.ToUserDto();
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken token = default)
    {
        var users = await _iUserRepository.GetAllUsers(token);
        var userDtos = users.Select(s=> s.ToUserDto()).ToList();
        return userDtos;
    }

    public async Task<(UserDto?, UserDto?)> FollowUserAsync(long followerId, long followingId, CancellationToken token = default)
    {
        (User follower, User following) = await _iUserRepository.FollowUserAsync(followerId, followingId, token);
        if (follower is null || following == null)
        {
            return (null, null);
        }
        return (follower.ToUserDto(), following.ToUserDto());
    }

    public async Task<bool> DeleteUserAsync(long userId, CancellationToken token)
    {
        return await _iUserRepository.DeleteUserAsync(userId, token);
    }
}