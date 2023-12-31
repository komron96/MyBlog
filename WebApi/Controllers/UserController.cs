using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic;
namespace WebApi;

[ApiController]
[Route("users")]
[Authorize]
public sealed class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService, IOptionsMonitor<ConnectionStrings> options)
    {
        _userService = userService;
    }

    //http://localhost:5191/users
    [HttpPost]
    [AllowAnonymous]
    public  Task<UserDto> CreateUserAsync([FromBody] UserDto UserDto, CancellationToken token = default)
    {
        return _userService.CreateUserAsync(UserDto, token);
    }

    [HttpGet]
    public Task<IEnumerable<UserDto>> GetAllToDoItems(CancellationToken token = default)
    {
        return _userService.GetAllUsersAsync(token);
    }

    [HttpPost("{followerId}/follow/{followingId}")]
    public async Task<IActionResult> FollowUserAsync(long followerId, long followingId, CancellationToken token)
    {
        (UserDto? followerUserDto, UserDto? followingUserDto) = await _userService.FollowUserAsync(followerId, followingId, token);

        if (followerUserDto == null || followingUserDto == null)
        {
            throw new UserNotFoundException();
        }

        UserDto followerUser = followerUserDto.Value;
        UserDto followingUser = followingUserDto.Value;

        var followerUserClass = ConverterToClass.ToUserClass(followerUser);
        var followingUserClass = ConverterToClass.ToUserClass(followingUser);

        if (followerUserClass != null && followingUserClass != null)
        {
            if (followerUserClass.Following != null && followerUserClass.Following.Contains(followingUserClass))
            {
                return Conflict($"You have already subscribed to {followingUserClass.FirstName} {followingUserClass.LastName}");
            }
            return Ok($"Successfully subscribed to {followingUserClass.FirstName} {followingUserClass.LastName}");
        }
        else
        {
            throw new UserNotFoundException();
        }
    }

    //http://localhost:5191/users?userId=1
    [HttpDelete]
    public Task<bool> DeleteUserAsync([FromQuery] long userId, CancellationToken token)
    {
        return _userService.DeleteUserAsync(userId, token);
    }
}
