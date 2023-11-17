namespace DataAccess;

public interface IPostRepository
{
    public ValueTask<Post> CreatePostAsync(Post post, User user, CancellationToken token);
    public ValueTask<IEnumerable<Post>> GetAllPosts(CancellationToken token);
    public ValueTask<IEnumerable<Post>> GetPostsByUserIdAsync(long userId, CancellationToken token);
}
