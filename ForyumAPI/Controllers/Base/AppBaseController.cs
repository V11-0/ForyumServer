using ForyumAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ForyumAPI.Controllers.Base;

public abstract class AppBaseController : ControllerBase {

    private protected readonly IUserRepository _userRepository;

    private protected AppBaseController(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    private protected string GetTokenFromHeader() {
        string token = Request.Headers["Authorization"];
        token = token.Substring(7);

        return token;
    }

    private protected async Task<int> GetUserIdFromToken() {
        string token = GetTokenFromHeader();
        var user = await _userRepository.GetUserByToken(token);

        return user.Id;
    }
}