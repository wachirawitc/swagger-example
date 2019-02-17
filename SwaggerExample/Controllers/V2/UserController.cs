using Microsoft.AspNetCore.Mvc;
using SwaggerExample.Infrastructures.Constants;

namespace SwaggerExample.Controllers.V2
{
    [Produces("application/json")]
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