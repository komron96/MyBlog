using Microsoft.EntityFrameworkCore;
namespace DataAccess;

public sealed class EFCorePostRepository : IPostRepository
{
    private readonly AppDbContext _appDbContext;

    public EFCorePostRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async ValueTask<Post> CreatePostAsync(Post post, User user, CancellationToken token)
    {
        await _appDbContext.Users.FindAsync(post);

        user.Id = post.UserId; 
        await _appDbContext.Posts.AddAsync(post, token);
        await _appDbContext.SaveChangesAsync(token);
        return post;
    }

    public async ValueTask<IEnumerable<Post>> GetAllPosts(CancellationToken token)
    {
        return await _appDbContext.Posts.ToListAsync(token);
    }

    public async ValueTask<IEnumerable<Post>> GetPostsByUserIdAsync(long userId, CancellationToken token)
    {
        return await _appDbContext.Posts
            .Where(post => post.UserId == userId)
            .ToListAsync(token);
    }
}