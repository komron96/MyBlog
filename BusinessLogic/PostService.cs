using DataAccess;
namespace BusinessLogic;



public sealed class PostService : IPostService
{
    private readonly IPostRepository _iPostRepository;

    public PostService(IPostRepository iPostRepository)
    {
        _iPostRepository = iPostRepository;
    }

    public async Task<PostDto?> CreatePostAsync(PostDto postDto, long userId, CancellationToken token)
    {
        Post? post = await _iPostRepository.CreatePostAsync(postDto.ToPostClass(), userId, token) ?? throw new NotFoundEntity("Пользователь не найден при попытке создать пост");
        return post.ToPostDto();
    }

    public async Task<IEnumerable<PostDto>> GetAllPosts(CancellationToken token)
    {
        var posts = await _iPostRepository.GetAllPosts(token);
        var postDtos = posts.Select(s => s.ToPostDto()).ToList();
        return postDtos;
    }

    public async Task<IEnumerable<PostDto>> GetPostsByUserIdAsync(long userId, CancellationToken token)
    {
        var posts = await _iPostRepository.GetPostsByUserIdAsync(userId, token);
        var postDtos = posts.Select(s => s.ToPostDto()).ToList();
        return postDtos;
    }

    public async Task<bool> DeletePostAsync(long postId, CancellationToken token)
    {
        return await _iPostRepository.DeletePostAsync(postId, token);
    }
}