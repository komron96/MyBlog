using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using Microsoft.AspNetCore.Authorization;
namespace WebApi;

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

    //http://localhost:5191/posts/create?userId=1
    [HttpPost("create")]
    public async Task<PostDto?> CreatePostAsync([FromBody] PostDto postDto, [FromQuery] long userId, CancellationToken token)
    {
        return await _postService.CreatePostAsync(postDto, userId, token);
    }

    [HttpGet]
    public async Task<IEnumerable<PostDto>> GetPosts(CancellationToken token = default)
    {
        return await _postService.GetAllPosts(token);
    }

    [HttpGet("user/{userId}")]
    [AllowAnonymous]
    public async  Task<IEnumerable<PostDto>> GetPostsByUserIdAsync([FromRoute] long userId, CancellationToken token)
    {
        return await _postService.GetPostsByUserIdAsync(userId, token);
    }

    //http://localhost:5191/posts?id=1
    [HttpDelete]
    public async Task<bool> DeletePostAsync([FromRoute] long postId, CancellationToken token)
    {
        return await _postService.DeletePostAsync(postId, token);
    }
}