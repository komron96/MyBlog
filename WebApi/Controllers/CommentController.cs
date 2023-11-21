using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using Microsoft.AspNetCore.Authorization;

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

    [HttpPost("create/{postId}")]
    public async ValueTask<CommentDto> AddCommentAsync([FromBody] CommentDto commentDto, [FromRoute] long postId, CancellationToken token)
    {
        return await _commentService.AddCommentAsync(commentDto, postId, token);
    }

    [HttpGet]
    [AllowAnonymous]
    public async ValueTask<IEnumerable<CommentDto>> GetPostsAsync(CancellationToken token = default)
    {
        return await _commentService.GetAllCommentsAsync(token);
    }

    [HttpGet("post/{postId}")]
    public async Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(long postId, CancellationToken token)
    {
        return await _commentService.GetCommentsByPostIdAsync(postId, token);
    }
}