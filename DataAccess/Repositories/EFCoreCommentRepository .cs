using Microsoft.EntityFrameworkCore;
namespace DataAccess;

public sealed class EFCommentostRepository : ICommentRepository
{
    private readonly AppDbContext _appDbContext;

    public EFCommentostRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Comment> CreateCommentAsync(Comment comment, long postId, CancellationToken token)
    {
        var post = await _appDbContext.Posts.FindAsync(postId, token);

        comment.PostId = postId;
        comment.Post = post;

        await _appDbContext.Comments.AddAsync(comment, token);
        await _appDbContext.SaveChangesAsync(token);
        return comment;
    }

    public async Task<IEnumerable<Comment>> GetAllComments(CancellationToken token)
    {
        return await _appDbContext.Comments.ToListAsync(token);
    }

    public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(long postId, CancellationToken token)
    {
        return await _appDbContext.Comments
            .Where(comment => comment.PostId == postId)
            .ToListAsync(token);
    }
}