namespace DataAccess;

public interface IPostRepository
{
    public Task<Post?> CreatePostAsync(Post post, long userId, CancellationToken token);
    public Task<IEnumerable<Post>> GetAllPosts(CancellationToken token);
    public Task<IEnumerable<Post>> GetPostsByUserIdAsync(long userId, CancellationToken token);
    public Task<bool> DeletePostAsync(long postId, CancellationToken token);
}
