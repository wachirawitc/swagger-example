using Microsoft.AspNetCore.Mvc;
using SwaggerExample.Constants;

namespace SwaggerExample.Controllers.V1
{
    [ApiVersion(ApiVersioning.V1)]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost(nameof(Login))]
        public string Login(string username, string password, string returnUrl)
        {
            return "Login from V1";
        }
    }
}