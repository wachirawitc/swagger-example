using Microsoft.AspNetCore.Mvc;
using SwaggerExample.Constants;

namespace SwaggerExample.Controllers.V2
{
    [ApiVersion(ApiVersioning.V2)]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost(nameof(Login))]
        public string Login(string username, string password)
        {
            return "Login from V2";
        }
    }
}