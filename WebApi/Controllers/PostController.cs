using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using DataAccess;

[ApiController]
[Route("/api/v1/posts")]
public sealed class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpPost("/api/v1/posts/create")]
    public async ValueTask<Post> CreatePostAsync([FromBody] Post post, [FromQuery] long userId, CancellationToken token)
    {
        return await _postService.CreatePostAsync(post, userId, token);
    }

    [HttpGet]
    public ValueTask<IEnumerable<Post>> GetAllToDoItems(CancellationToken token = default)
    {
        return _postService.GetAllPosts(token);
    }
}