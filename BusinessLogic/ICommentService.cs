namespace BusinessLogic;

public interface ICommentService
{
    public Task<CommentDto> AddCommentAsync(CommentDto commentDto, long postId, CancellationToken token);
    public Task<IEnumerable<CommentDto>> GetAllCommentsAsync(CancellationToken token);
    public Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(long postId, CancellationToken token);
}