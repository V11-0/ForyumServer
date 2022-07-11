using ApplicationCore.Models;
using ForyumAPI.Models.DTO;
using ForyumAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForyumAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CommunityController : ControllerBase
{
    private readonly ICommunityRepository _repository;

    public CommunityController(ICommunityRepository repository) {
        _repository = repository;
    }

    [HttpGet]
    [Route("Recommended")]
    public IEnumerable<CommunityBasicDTO> GetRecommended() {
        return _repository.GetRecommended();
    }
}