using Microsoft.AspNetCore.Mvc;

namespace ForyumAPI.Controllers.Base;

public abstract class AppBaseController : ControllerBase {
    private protected string GetTokenFromHeader() {
        string token = Request.Headers["Authorization"];
        token = token.Substring(7);

        return token;
    }
}