using ApplicationCore.Models;

namespace ForyumAPI.Models.DTO;

public class UserBasicDTO
{
    public UserBasicDTO(string username, string country, string? bio, IEnumerable<CommunityBasicDTO>? communities = null, IEnumerable<PostFeedDTO>? posts = null)
    {
        Username = username;
        Country = country;
        Bio = bio;
        Communities = communities;
        Posts = posts;
    }

    public string Username { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string? Bio { get; set; }

    public IEnumerable<CommunityBasicDTO>? Communities { get; set; }
    public IEnumerable<PostFeedDTO>? Posts { get; set; }

    public static UserBasicDTO fromUser(User user, IEnumerable<CommunityBasicDTO>? communities = null, IEnumerable<PostFeedDTO>? posts = null)
    {
        return new UserBasicDTO(user.Username, user.Country, user.Bio, communities, posts);
    }
}

public class UserCreationDTO
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Country { get; set; } = null!;

    public static User toUser(UserCreationDTO userCreationDTO)
    {
        User user = new User()
        {
            Username = userCreationDTO.Username,
            Email = userCreationDTO.Email,
            Password = userCreationDTO.Password,
            Country = userCreationDTO.Country,
        };

        return user;
    }
}

public class UserLoginDTO
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class UserUpdateDTO
{
    public string bio { get; set; } = null!;
}