using Microsoft.EntityFrameworkCore;
namespace DataAccess;

public sealed class EFCoreCommentRepository : ICommentRepository
{
    private readonly AppDbContext _appDbContext;

    public EFCoreCommentRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Comment> AddCommentAsync(Comment comment, long postId, CancellationToken token)
    {
        Post? post = await _appDbContext.Posts.FindAsync(new object?[] { postId }, cancellationToken: token);
        if (post != null)
        {
            post.Id = postId;

            await _appDbContext.Comments.AddAsync(comment, token);
            await _appDbContext.SaveChangesAsync(token);
            return comment;
        }
        else
        {
            return null;
        }
    }
    public async Task<IEnumerable<Comment>> GetAllCommentsAsync(CancellationToken token)
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