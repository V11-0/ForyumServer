using ApplicationCore.Models;

namespace ForyumAPI.Models.DTO;

public class UserBasicDTO
{
    public UserBasicDTO(string username, string country, string? bio)
    {
        Username = username;
        Country = country;
        Bio = bio;
    }

    public string Username { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string? Bio { get; set; }

    public static UserBasicDTO fromUser(User user)
    {
        return new UserBasicDTO(user.Username, user.Country, user.Bio);
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
            Country = userCreationDTO.Country
        };

        return user;
    }
}