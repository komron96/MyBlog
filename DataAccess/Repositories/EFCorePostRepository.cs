using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public sealed class EFCorePostRepository : IPostRepository
{
    private readonly AppDbContext _appDbContext;

    public EFCorePostRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Post?> CreatePostAsync(Post post, long userId, CancellationToken token)
    {
        User? user = await _appDbContext.Users.FindAsync(new object?[] { userId }, cancellationToken: token);
        if (user != null)
        {
            post.UserId = userId;
            post.User = user;

            _appDbContext.Posts.Add(post);
            await _appDbContext.SaveChangesAsync(token);
            return post;
        }
        else
        {
            return null;
        }
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
        Post ?post = await _appDbContext.Posts.FindAsync(new object?[] { postId }, cancellationToken: token);
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