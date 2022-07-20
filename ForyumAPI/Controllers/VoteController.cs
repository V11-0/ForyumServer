using ForyumAPI.Controllers.Base;
using ForyumAPI.Repositories;
using ForyumAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForyumAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class VoteController : AppBaseController {

    private readonly IVoteRepository _repository;
    private readonly IUserRepository _userRepository;

    public VoteController(IVoteRepository repository, IUserRepository userRepository) {
        _repository = repository;
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task Vote(VoteDTO dto) {
        var user = await _userRepository.GetUserByToken(GetTokenFromHeader());
        await _repository.Create(dto, user.Id);
    }

    [HttpDelete]
    public async Task RemoveVote(int postId) {
        var user = await _userRepository.GetUserByToken(GetTokenFromHeader());
        await _repository.Delete(postId, user.Id);
    }
}