using DataAccess;
namespace BusinessLogic;


//Converters of Classes to To DTO
public static class ConverterToDto
{
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.RegDate.ToString("yyyy-MM-dd"));
    }

    public static PostDto ToPostDto(this Post post)
    {
        return new PostDto(
            post.Id,
            post.Title,
            post.Content,
            post.Likes,
            post.CreatedAt.ToString("yyyy-MM-dd"),
            post.UserId,
            post.User);
    }

    public static CommentDto ToCommentDto(this Comment comment)
    {
        return new CommentDto(
            comment.Id,
            comment.Text,
            comment.CreatedAt.ToString("yyyy-MM-dd"),
            comment.Post,
            comment.PostId,
            comment.User,
            comment.UserId);
    }


}



//Converters of DTO to Class

public static class ConverterToClass
{
    public static User ToUserClass(this UserDto userDto)
    {
        return new User
        {
            Id = userDto.Id,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            RegDate = DateTime.Parse(userDto.RegDate)
        };
    }

    public static Post ToPostClass(this PostDto postDto)
    {
        return new Post
        {
            Id = postDto.Id,
            Title = postDto.Title,
            Content = postDto.Content,
            Likes = postDto.Likes,
            CreatedAt = DateTime.Parse(postDto.CreatedAt),
            UserId = postDto.UserId,
            User = postDto.User
        };
    }
    public static Comment ToCommentClass(this CommentDto commentDto)
    {
        return new Comment
        {
            Id = commentDto.Id,
            Text = commentDto.Text,
            CreatedAt = DateTime.Parse(commentDto.CreatedAt),
            Post = commentDto.Post,
            PostId = commentDto.PostId,
            User = commentDto.User,
            UserId = commentDto.UserId
        };
    }
}