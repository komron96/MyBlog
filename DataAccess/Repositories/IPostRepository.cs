namespace DataAccess;

public interface IPostRepository
{
    public ValueTask<Post> CreatePostAsync(Post post, long userId, CancellationToken token);
    public ValueTask<IEnumerable<Post>> GetAllPosts(CancellationToken token);
}
