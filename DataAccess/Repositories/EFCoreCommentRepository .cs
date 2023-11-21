using Microsoft.EntityFrameworkCore;
namespace DataAccess;

public sealed class EFCommentostRepository : ICommentRepository
{
    private readonly AppDbContext _appDbContext;

    public EFCommentostRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Comment> AddCommentAsync(Comment comment, long postId, CancellationToken token)
    {
        Post post = await _appDbContext.Posts.FindAsync(postId);

        if (post != null)
        {
            post.Comments.Add(comment);

            await _appDbContext.SaveChangesAsync(token);
            return comment;
        }
        return null;
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