using DataAccess;

namespace BusinessLogic;
public static class Converter
{
    public static PostInfo ToPostInfo(this Post post)
    {
        return new PostInfo(
            post.Id,
            post.Title,
            post.Content,
            post.CreatedAt,
            post.Likes,
            post.Visibility.ToString());
    }

    public static UserInfo ToUserInfo(this User user)
    {
        return new UserInfo(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.RegDate);
    }
}
