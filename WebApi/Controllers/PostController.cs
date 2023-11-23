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
    public Task<PostDto?> CreatePostAsync([FromBody] PostDto postDto, [FromQuery] long userId, CancellationToken token)
    {
        return _postService.CreatePostAsync(postDto, userId, token);
    }

    [HttpGet]
    public Task<IEnumerable<PostDto>> GetPosts(CancellationToken token = default)
    {
        return _postService.GetAllPosts(token);
    }

    [HttpGet("user/{userId}")]
    [AllowAnonymous]
    public  Task<IEnumerable<PostDto>> GetPostsByUserIdAsync([FromRoute] long userId, CancellationToken token)
    {
        return _postService.GetPostsByUserIdAsync(userId, token);
    }

    //http://localhost:5191/posts?id=1
    [HttpDelete]
    public Task<bool> DeletePostAsync([FromRoute] long postId, CancellationToken token)
    {
        return _postService.DeletePostAsync(postId, token);
    }
}