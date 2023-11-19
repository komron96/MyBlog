using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using DataAccess;

[ApiController]
[Route("comment")]
public sealed class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost("create/{postId}")]
    public async ValueTask<Comment> CreatePostAsync([FromBody] Comment comment, [FromRoute] long postId, CancellationToken token)
    {
        return await _commentService.CreateCommentAsync(comment, postId, token);
    }

    [HttpGet]
    public async ValueTask<IEnumerable<Comment>> GetPosts(CancellationToken token = default)
    {
        return await _commentService.GetAllComments(token);
    }

    [HttpGet("post/{postId}")]
    public async Task<ActionResult<ICollection<Post>>> GetCommentsByPostId(long postId, CancellationToken token)
    {
        try
        {
            var comment = await _commentService.GetCommentsByPostIdAsync(postId, token);
            return Ok(comment);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}