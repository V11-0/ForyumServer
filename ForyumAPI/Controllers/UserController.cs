using ApplicationCore.Models;
using ForyumAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForyumAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase {

    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository) {
        _repository = repository;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task CreateUser(User user) {
        await _repository.Insert(user);
    }
}