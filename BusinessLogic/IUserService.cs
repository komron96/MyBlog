namespace BusinessLogic;
public interface IUserService
{
    Task<UserDto> CreateUserAsync(UserDto userDto, CancellationToken token = default);
    Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken token = default);
    Task<(UserDto?, UserDto?)> FollowUserAsync(long followerId, long followingId, CancellationToken token = default);
    Task<bool> DeleteUserAsync(long userId, CancellationToken token = default);
}
