using Microsoft.EntityFrameworkCore;
namespace DataAccess;

public sealed class EFCorePostRepository : IPostRepository
{
    private readonly AppDbContext _appDbContext;

    public EFCorePostRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Post> CreatePostAsync(Post post, long userId, CancellationToken token)
    {
        var user = await _appDbContext.Users.FindAsync(userId);
        post.UserId = userId;
        post.User = user;
        await _appDbContext.Posts.AddAsync(post, token);
        await _appDbContext.SaveChangesAsync(token);
        return post;
    }

    public async Task<IEnumerable<Post>> GetAllPosts(CancellationToken token)
    {
        return await _appDbContext.Posts.ToListAsync(token);
    }

    public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(long userId, CancellationToken token)
    {
        return await _appDbContext.Posts
            .Where(post => post.UserId == userId)
            .ToListAsync(token);
    }


    public async Task<bool> DeletePostAsync(long postId, CancellationToken token)
    {
        var post = await _appDbContext.Posts.FirstOrDefaultAsync(p => p.Id == postId, cancellationToken: token);
        if (post != null)
        {
            _appDbContext.Posts.Remove(post);
            await _appDbContext.SaveChangesAsync(token);
            return true;
        }
        else
        {
            return false;
        }
    }
}