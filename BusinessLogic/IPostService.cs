using DataAccess;
namespace BusinessLogic;

public interface IPostService
{
    Task<Post> CreatePostAsync(Post post, long userId, CancellationToken token);
    Task<IEnumerable<Post>> GetAllPosts(CancellationToken token);
    Task<IEnumerable<Post>> GetPostsByUserIdAsync(long userId, CancellationToken token);
    Task<Post> DeletePostAsync(long postId, CancellationToken token);
}

public sealed class PostService : IPostService
{
    private readonly IPostRepository _iPostRepository;

    public PostService(IPostRepository iPostRepository)
    {
        _iPostRepository = iPostRepository;
    }

    public async Task<Post> CreatePostAsync(Post post, long userId, CancellationToken token)
    {
        return await _iPostRepository.CreatePostAsync(post, userId, token);
    }

    public async Task<IEnumerable<Post>> GetAllPosts(CancellationToken token)
    {
        return await _iPostRepository.GetAllPosts(token);
    }

    public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(long userId, CancellationToken token)
    {
        return await _iPostRepository.GetPostsByUserIdAsync(userId, token);
    }
    public async Task<Post> DeletePostAsync(long postId, CancellationToken token)
    {
        return await _iPostRepository.DeletePostAsync(postId, token);
    }
}