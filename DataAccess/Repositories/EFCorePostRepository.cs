using BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public interface IPostRepository
{
    public ValueTask<Post> CreatePostAsync(Post post, CancellationToken token);
    public ValueTask<IEnumerable<Post>> GetAllPosts(CancellationToken token);
}

public sealed class EFCorePostRepository : IPostRepository
{
    private readonly IAppDbContext _appDbcontext;

    public EFCorePostRepository(IAppDbContext appDbcontext)
    {
        _appDbcontext = appDbcontext;
    }
    public async ValueTask<Post> CreatePostAsync(Post post, CancellationToken token)
    {
        await _appDbcontext.Posts.AddAsync(post, token);
        await _appDbcontext.SaveChangesAsync(token);
        return post;
    }

    public async ValueTask<IEnumerable<Post>> GetAllPosts(CancellationToken token)
    {
        return await _appDbcontext.Posts.ToListAsync(token);   
    }
}