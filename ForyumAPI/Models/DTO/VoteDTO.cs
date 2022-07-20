using ApplicationCore.Models;

namespace ForyumAPI.Models.DTO;

public class VoteDTO {
    public VoteType VoteType { get; set; }
    public int PostId { get; set; }
}