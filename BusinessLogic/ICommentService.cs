using DataAccess;
namespace BusinessLogic;

public interface ICommentService
{
    public Task<CommentDto> AddCommentAsync(Comment comment, long postId, CancellationToken token);
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

    public Task<CommentDto> AddCommentAsync(Comment comment, long postId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    // public async Task<CommentDto> AddCommentAsync(CommentDto commentDto, long userId, CancellationToken token)
    // {
    //     Comment comment = await _iCommentRepository.AddCommentAsync(commentDto.ToCommentClass(), userId, token);
    //     if (post is null)
    //         return null;
    //     return post.ToPostDto();
    // }

    public async Task<IEnumerable<Comment>> GetAllComments(CancellationToken token)
    {
        return await _iCommentRepository.GetAllComments(token);
    }

    public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(long postId, CancellationToken token)
    {
        return await _iCommentRepository.GetCommentsByPostIdAsync(postId, token);
    }
}