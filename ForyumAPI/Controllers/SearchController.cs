using ForyumAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForyumAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase {

    private readonly ISearchRepository _repository;

    public SearchController(ISearchRepository repository) {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<SearchCompletion>> Search(string val) {
        return await _repository.Search(val);
    }
}