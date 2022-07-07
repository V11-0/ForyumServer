using ApplicationCore.Models;
using ForyumAPI.Models;
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
    public async Task<ActionResult<User>> CreateUser(User user) {

        // Check for unique username and email
        var usernameExists = await _repository.CheckForUsername(user.Username);
        var emailExists = await _repository.CheckForEmail(user.Email);

        if (usernameExists || emailExists) {
            var errors = new List<ValidationError>();

            if (usernameExists) {
                errors.Add(new ValidationError("username", "O nome de usuário já existe"));
            }

            if (emailExists) {
                errors.Add(new ValidationError("email", "O email já existe"));
            }

            return Conflict(errors);
        }

        var createdUser = await _repository.Insert(user);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<User?>> GetUserById(int id) {
        var user = await _repository.GetById(id);

        if (user != null) {
            return user;
        }

        return NotFound();
    }
}