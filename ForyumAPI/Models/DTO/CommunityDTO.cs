using ApplicationCore.Models;

namespace ForyumAPI.Models.DTO;

public class CommunityBasicDTO
{
    public int id { get; set; }
    public string name { get; set; }
    public string? description { get; set; }
    public int? creatorUserId { get; set; }
    public string? creatorUsername { get; set; }
    public int? userCount { get; set; }

    public CommunityBasicDTO(int id, string name, string? description, int? userCount, int? creatorUserId = null, string? creatorUsername = null)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.userCount = userCount;
        this.creatorUserId = creatorUserId;
        this.creatorUsername = creatorUsername;
    }
}