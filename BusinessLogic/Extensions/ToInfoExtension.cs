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
            post.Comments,
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


        public static Post ToPostInfo2(this PostInfo postInfo)
    {
        return new Post
        {
            Id = postInfo.Id,
            Title = postInfo.Title,
            Content = postInfo.Content,
            CreatedAt = postInfo.CreatedAt,
            Likes = postInfo.Likes,
            Comments = postInfo.Comments,
            Visibility = Enum.Parse<Visibility>(postInfo.Visibility)
        };
    }

}
