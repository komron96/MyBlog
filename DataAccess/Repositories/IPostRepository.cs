namespace DataAccess;

public interface IPostRepository
{
    public ValueTask<Post> CreatePostAsync(Post post, CancellationToken token);
    public ValueTask<IEnumerable<Post>> GetAllPosts(CancellationToken token);
}
