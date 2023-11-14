using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public sealed class EFCorePostRepository : IPostRepository
{
    private readonly AppDbContext _appDbContext;

    public EFCorePostRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async ValueTask<Post> CreatePostAsync(Post post, CancellationToken token)
    {
        await _appDbContext.Posts.AddAsync(post, token);
        await _appDbContext.SaveChangesAsync(token);
        return post;
    }

    public async ValueTask<IEnumerable<Post>> GetAllPosts(CancellationToken token)
    {
        return await _appDbContext.Posts.ToListAsync(token);   
    }
}