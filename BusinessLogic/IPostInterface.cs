namespace BusinessLogic;

public interface IPostService
{
    Task<PostDto?> CreatePostAsync(PostDto postDto, long userId, CancellationToken token);
    Task<IEnumerable<PostDto>> GetAllPosts(CancellationToken token);
    Task<IEnumerable<PostDto>> GetPostsByUserIdAsync(long userId, CancellationToken token);
    Task<bool> DeletePostAsync(long postId, CancellationToken token);
}
