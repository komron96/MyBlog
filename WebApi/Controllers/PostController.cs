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
    public async Task<Post> CreatePostAsync([FromBody] Post post, [FromQuery] long userId, CancellationToken token)
    {
        return await _postService.CreatePostAsync(post, userId, token);
    }

    [HttpGet]
    public async Task<IEnumerable<Post>> GetPosts(CancellationToken token = default)
    {
        return await _postService.GetAllPosts(token);
    }

    [HttpGet("user/{userId}")]
    [AllowAnonymous]
    public async  Task<IEnumerable<Post>> GetPostsByUserIdAsync([FromRoute] long userId, CancellationToken token)
    {
        return await _postService.GetPostsByUserIdAsync(userId, token);
    }

    //http://localhost:5191/posts?id=1
    [HttpDelete]
    public async Task<Post> DeletePostAsync([FromRoute] long postId, CancellationToken token)
    {
        return await _postService.DeletePostAsync(postId, token) ?? throw new PostNotFoundException();
    }
}