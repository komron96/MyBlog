using DataAccess;

namespace BusinessLogic;
public static class Converter
{
    public static PostDto ToPostDto(this Post post)
    {
        return new PostDto(
            post.Id,
            post.Title,
            post.Content,
            post.Likes,
            post.CreatedAt,
            post.Visibility);
    }

    public static UserDto ToUserDto(this User user)
    {
        return new UserDto(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.RegDate);
    }
}
