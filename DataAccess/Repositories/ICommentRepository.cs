namespace DataAccess;

public interface ICommentRepository
{
    public Task<Comment> CreateCommentAsync(Comment comment, long postId, CancellationToken token);
    public Task<IEnumerable<Comment>> GetAllComments(CancellationToken token);
    public Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(long postId, CancellationToken token);
}
