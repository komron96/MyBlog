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

    [HttpPost]
    public ValueTask<Post> CreatePostAsync([FromBody] Post post, CancellationToken token = default)
    {
        return _postService.CreatePostAsync(post, token);
    }

    [HttpGet]
    public ValueTask<IEnumerable<Post>> GetAllToDoItems(CancellationToken token = default)
    {
        return _postService.GetAllPosts(token);
    }
}