using Microsoft.AspNetCore.Mvc;
using SwaggerExample.Infrastructures.Constants;
using SwaggerExample.ViewModel;

namespace SwaggerExample.Controllers.V1
{
    [Produces("application/json")]
    [ApiVersion(ApiVersioning.V1)]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost(nameof(Login))]
        [ProducesResponseType(typeof(LoginResponseViewModel), 200)]
        public string Login(LoginViewModel model)
        {
            var header = Request.Headers;
            var imei = header["imei"].ToString();
            return "Login from V1";
        }
    }
}