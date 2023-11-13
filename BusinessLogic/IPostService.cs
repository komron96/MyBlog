using DataAccess;
using Microsoft.EntityFrameworkCore;
namespace BusinessLogic;

public interface IPostService
{
    Task<Post> CreatePostAsync(Post post, CancellationToken token);
    Task<IEnumerable<Post>> GetAllPosts(CancellationToken token);

}

public sealed class PostService : IPostService
{
    private readonly AppDbContext _apDbContext;
    public PostService(AppDbContext appDbContext)
    {
        _apDbContext = appDbContext;
    }

    public async Task<Post> CreatePostAsync(Post post, CancellationToken token)
    {
        await _apDbContext.Posts.AddAsync(post, token);
        await _apDbContext.SaveChangesAsync(token);
        return post;
    }

    public async Task<IEnumerable<Post>> GetAllPosts(CancellationToken token)
    {
        return await _apDbContext.Posts.ToListAsync(token);
    }
}