using DataAccess;
namespace BusinessLogic;

public interface ICommentService
{
    public Task<CommentDto> AddCommentAsync(CommentDto commentDto, long postId, CancellationToken token);
    public Task<IEnumerable<CommentDto>> GetAllCommentsAsync(CancellationToken token);
    public Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(long postId, CancellationToken token);
}

public sealed class CommentService : ICommentService
{
    private readonly ICommentRepository _iCommentRepository;

    public CommentService(ICommentRepository iCommentRepository)
    {
        _iCommentRepository = iCommentRepository;
    }


    public async Task<CommentDto> AddCommentAsync(CommentDto commentDto, long postId, CancellationToken token)
    {
        Comment comment = await _iCommentRepository.AddCommentAsync(commentDto.ToCommentClass(), postId, token);
        return comment.ToCommentDto();
    }

    public async Task<IEnumerable<CommentDto>> GetAllCommentsAsync(CancellationToken token)
    {
        var comments = await _iCommentRepository.GetAllCommentsAsync(token);
        var commentsDto = comments.Select(s => s.ToCommentDto()).ToList();
        return commentsDto;
    }

    public async Task<IEnumerable<CommentDto>> GetCommentsByPostIdAsync(long postId, CancellationToken token)
    {
        var comments = await _iCommentRepository.GetCommentsByPostIdAsync(postId, token);
        var commentsDto = comments.Select(s => s.ToCommentDto()).ToList();
        return commentsDto;
    }
}