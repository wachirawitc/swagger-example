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
        public ObjectResult Login(LoginViewModel model)
        {
            var header = Request.Headers;
            var imei = header["imei"].ToString();
            return Ok("Login from V1");
        }

        [HttpPost(nameof(GetUserInfo))]
        public ObjectResult GetUserInfo(UserInfoRequestViewModel model)
        {
            return Ok($"Info of {model.UserName}");
        }
    }
}