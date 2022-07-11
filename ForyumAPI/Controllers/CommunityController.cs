using ApplicationCore.Models;
using ForyumAPI.Controllers.Base;
using ForyumAPI.Models.DTO;
using ForyumAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForyumAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CommunityController : AppBaseController
{
    private readonly ICommunityRepository _repository;

    public CommunityController(ICommunityRepository repository) {
        _repository = repository;
    }

    [HttpGet]
    [Route("Recommended")]
    public async Task<IEnumerable<CommunityBasicDTO>> GetRecommended() {
        return await _repository.GetRecommended();
    }

    [HttpPost]
    [Route("Join/{communityId}")]
    public async Task JoinCommunity(int communityId) {
        await _repository.JoinCommunity(GetTokenFromHeader(), communityId);
    }
}