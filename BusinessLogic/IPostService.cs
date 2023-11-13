using DataAccess;
namespace BusinessLogic;

public interface IPostService
{
    ValueTask<Post> CreatePostAsync(Post post, CancellationToken token);
    ValueTask<IEnumerable<Post>> GetAllPosts(CancellationToken token);

}

public sealed class PostService : IPostService
{
    private readonly IPostRepository _iPostRepository;

    public PostService(IPostRepository iPostRepository)
    {
        _iPostRepository = iPostRepository;
    }

    public ValueTask<Post> CreatePostAsync(Post post, CancellationToken token)
    {
        return _iPostRepository.CreatePostAsync(post, token);
    }

    public ValueTask<IEnumerable<Post>> GetAllPosts(CancellationToken token)
    {
        return _iPostRepository.GetAllPosts(token);
    }
}