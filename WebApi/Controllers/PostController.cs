using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("posts")]
[Authorize]
public sealed class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpPost("create")]
    public async ValueTask<ActionResult> CreatePostAsync([FromBody] Post post, [FromQuery] long userId, CancellationToken token)
    {
        var creatingPost = await _postService.CreatePostAsync(post, userId, token);
        if(creatingPost != null)
        {
            return Ok(creatingPost); 
        }
        else
        {
            return NotFound("User not found");
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public async ValueTask<IEnumerable<Post>> GetPosts(CancellationToken token = default)
    {
        return await _postService.GetAllPosts(token);
    }

    [HttpGet("user/{userId}")]
    [AllowAnonymous]
    public async Task<ActionResult> GetPostsByUserId([FromRoute] long userId, CancellationToken token)
    {
        var posts = await _postService.GetPostsByUserIdAsync(userId, token);
        if (posts != null && posts.Any())
        {
            return Ok(posts);
        }
        else
        {
            return NotFound("Posts not found");
        }
    }
}