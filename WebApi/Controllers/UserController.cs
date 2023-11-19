using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using DataAccess;



[ApiController]
[Route("users")]
public sealed class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<User> CreateUserAsync([FromBody] User user, CancellationToken token = default)
    {
        return await _userService.CreateUserAsync(user, token);
    }

    [HttpGet]
    public async Task<IEnumerable<User>> GetAllToDoItems(CancellationToken token = default)
    {
        return await _userService.GetAllUsers(token);
    }

    [HttpPost("{followerId}/follow/{followingId}")]
    public async Task<bool> FollowUserAsync([FromRoute] long followerId, [FromRoute] long followingId, CancellationToken token)
    {
        return await _userService.FollowUserAsync(followerId, followingId, token);
    }
}