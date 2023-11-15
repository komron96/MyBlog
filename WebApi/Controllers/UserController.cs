using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using DataAccess;



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
    public async ValueTask<User> CreateUserAsync([FromBody] User user, CancellationToken token = default)
    {
        return await _userService.CreateUserAsync(user, token);
    }

    [HttpGet]
    public async ValueTask<IEnumerable<User>> GetAllToDoItems(CancellationToken token = default)
    {
        return await _userService.GetAllUsers(token);
    }
}