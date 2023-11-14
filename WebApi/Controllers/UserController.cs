using Microsoft.AspNetCore.Mvc;
using BusinessLogic;



[ApiController]
[Route("/api/v1/users")]
public sealed class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public ValueTask<User> CreateUserAsync([FromBody] User user, CancellationToken token = default)
    {
        return _userService.CreateUserAsync(user, token);
    }

    [HttpGet]
    public ValueTask<IEnumerable<User>> GetAllToDoItems(CancellationToken token = default)
    {
        return _userService.GetAllUsers(token);
    }
}