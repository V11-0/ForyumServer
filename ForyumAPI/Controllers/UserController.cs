using ApplicationCore.Models;
using ForyumAPI.Models;
using ForyumAPI.Models.DTO;
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
    public async Task<ActionResult<User>> CreateUser(UserCreationDTO userCreationDTO) {

        // Check for unique username and email
        var usernameExists = await _repository.CheckForUsername(userCreationDTO.Username);
        var emailExists = await _repository.CheckForEmail(userCreationDTO.Email);

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

        var user = UserCreationDTO.toUser(userCreationDTO);
        var createdUser = await _repository.Insert(user);

        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, UserBasicDTO.fromUser(user));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<UserBasicDTO?>> GetUserById(int id) {
        var user = await _repository.GetById(id);

        if (user != null) {
            return UserBasicDTO.fromUser(user);
        }

        return NotFound();
    }
}