using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using DataAccess;

[ApiController]
[Route("posts")]
public sealed class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpPost("create/{userId}")]
    public async ValueTask<Post> CreatePostAsync([FromBody] Post post, [FromQuery] User user, CancellationToken token)
    {
        return await _postService.CreatePostAsync(post, user, token);
    }


    [HttpGet]
    public async ValueTask<IEnumerable<Post>> GetPosts(CancellationToken token = default)
    {
        return await _postService.GetAllPosts(token);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<ICollection<Post>>> GetPostsByUserId(long userId, CancellationToken token)
    {
        try
        {
            var posts = await _postService.GetPostsByUserIdAsync(userId, token);
            return Ok(posts);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}