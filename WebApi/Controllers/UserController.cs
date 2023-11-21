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

    [HttpPost]
    [AllowAnonymous]
    public async Task<UserDto> CreateUserAsync([FromBody] UserDto UserDto, CancellationToken token = default)
    {
        return (UserDto)await _userService.CreateUserAsync(UserDto, token);
    }

    [HttpGet]
    public async Task<IEnumerable<UserDto>> GetAllToDoItems(CancellationToken token = default)
    {
        return await _userService.GetAllUsersAsync(token);
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

    //http://localhost:5191/users?id=1
    [HttpDelete]
    public async Task<bool> DeleteUserAsync([FromRoute] long userId, CancellationToken token)
    {
        return await _userService.DeleteUserAsync(userId, token);
    }
}
