using DataAccess;
namespace BusinessLogic;

public interface IPostService
{
    ValueTask<Post> CreatePostAsync(Post post, User user, CancellationToken token);
    ValueTask<IEnumerable<Post>> GetAllPosts(CancellationToken token);
    ValueTask<IEnumerable<Post>> GetPostsByUserIdAsync(long userId, CancellationToken token);

}

public sealed class PostService : IPostService
{
    private readonly IPostRepository _iPostRepository;

    public PostService(IPostRepository iPostRepository)
    {
        _iPostRepository = iPostRepository;
    }

    public async ValueTask<Post> CreatePostAsync(Post post, User user, CancellationToken token)
    {
        return await _iPostRepository.CreatePostAsync(post, user, token);
    }

    public async ValueTask<IEnumerable<Post>> GetAllPosts(CancellationToken token)
    {
        return await _iPostRepository.GetAllPosts(token);
    }

    public async ValueTask<IEnumerable<Post>> GetPostsByUserIdAsync(long userId, CancellationToken token)
    {
        return await _iPostRepository.GetPostsByUserIdAsync(userId, token);
    }
}