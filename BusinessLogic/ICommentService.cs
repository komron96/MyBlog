using DataAccess;
namespace BusinessLogic;

public interface ICommentService
{
    public Task<Comment> CreateCommentAsync(Comment comment, long postId, CancellationToken token);
    public Task<IEnumerable<Comment>> GetAllComments(CancellationToken token);
    public Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(long postId, CancellationToken token);
}

public sealed class CommentService : ICommentService
{
    private readonly ICommentRepository _iCommentRepository;

    public CommentService(ICommentRepository iCommentRepository)
    {
        _iCommentRepository = iCommentRepository;
    }

    public async Task<Comment> CreateCommentAsync(Comment comment, long postId, CancellationToken token)
    {
        return await _iCommentRepository.CreateCommentAsync(comment, postId, token);
    }

    public async Task<IEnumerable<Comment>> GetAllComments(CancellationToken token)
    {
        return await _iCommentRepository.GetAllComments(token);
    }

    public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(long postId, CancellationToken token)
    {
        return await _iCommentRepository.GetCommentsByPostIdAsync(postId, token);
    }
}