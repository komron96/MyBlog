using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic;
using DataAccess;



[ApiController]
[Route("users")]
[Authorize]

public sealed class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IOptionsMonitor<ConnectionStrings> _options;

    public UserController(IUserService userService, IOptionsMonitor<ConnectionStrings> options)
    {
        _userService = userService;
        _options = options;
    }

    [HttpPost]
    [AllowAnonymous]
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
    public async Task<IActionResult> FollowUserAsync(long followerId, long followingId, CancellationToken token)
    {
        var (follower, following) = await _userService.FollowUserAsync(followerId, followingId, token);
        if (follower == null || following == null)
        {
            return NotFound("One or both users not found");
        }

        if (follower.Following.Contains(following))
        {
            return Conflict($"You have already subscriped to {following.FirstName} {following.LastName}");
        }
        
        
        return Ok($"Successfully subscribed to {following.FirstName} {following.LastName}");
    }
}
