using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using Microsoft.AspNetCore.Authorization;
namespace WebApi;

[ApiController]
[Route("comment")]
[Authorize]
public sealed class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost("create")]
    public Task<CommentDto> AddCommentAsync([FromBody] CommentDto commentDto, [FromQuery] long postId, CancellationToken token)
    {
        return _commentService.AddCommentAsync(commentDto, postId, token);
    }

    [HttpGet]
    [AllowAnonymous]
    public Task<IEnumerable<CommentDto>> GetPostsAsync(CancellationToken token = default)
    {
        return _commentService.GetAllCommentsAsync(token);
    }

    [HttpGet("post/{postId}")]
    public Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(long postId, CancellationToken token)
    {
        return _commentService.GetCommentsByPostIdAsync(postId, token);
    }
}