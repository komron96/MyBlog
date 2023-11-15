using Microsoft.EntityFrameworkCore;
namespace DataAccess;

public sealed class EFCorePostRepository : IPostRepository
{
    private readonly AppDbContext _appDbContext;

    public EFCorePostRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async ValueTask<Post> CreatePostAsync(Post post, long userId, CancellationToken token)
    {
        var user = await _appDbContext.Users.FindAsync(userId);
        
        post.User = user;
        await _appDbContext.Posts.AddAsync(post, token);
        await _appDbContext.SaveChangesAsync(token);
        return post;
    }

    public async ValueTask<IEnumerable<Post>> GetAllPosts(CancellationToken token)
    {
        return await _appDbContext.Posts.ToListAsync(token);
    }
}