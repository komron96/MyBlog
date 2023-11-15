using DataAccess;
namespace BusinessLogic;

public interface IPostService
{
    ValueTask<Post> CreatePostAsync(Post post, long userId, CancellationToken token);
    ValueTask<IEnumerable<Post>> GetAllPosts(CancellationToken token);

}

public sealed class PostService : IPostService
{
    private readonly IPostRepository _iPostRepository;

    public PostService(IPostRepository iPostRepository)
    {
        _iPostRepository = iPostRepository;
    }

    public async ValueTask<Post> CreatePostAsync(Post post, long userId, CancellationToken token)
    {
        return await _iPostRepository.CreatePostAsync(post, userId, token);
    }

    public async ValueTask<IEnumerable<Post>> GetAllPosts(CancellationToken token)
    {
        return await _iPostRepository.GetAllPosts(token);
    }
}