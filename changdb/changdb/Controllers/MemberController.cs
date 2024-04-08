using BusinessLogic.Token;
using BussinessLogic.IService;
using ControllerAPI.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace changdb.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize(Roles = EnumClass.RoleNames.Staff)]
    public class MemberController : Controller
    {
        IMemberService _user;
        IConfiguration _config;

        public MemberController(IMemberService user, IConfiguration config)
        {
            _user = user;
            _config = config ?? throw new ArgumentNullException(nameof(config));
            ProvideToken.Initialize(_config);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            var checkLogin = _user.Login(username, password);
            if (checkLogin != null)
            {
                var token = ProvideToken.Instance.GenerateToken(checkLogin);
                return Ok(token);
            }
            return Unauthorized("Username or password wrong, please try login!");
        }
        [HttpGet]
        public IActionResult Logout()
        {
            return Ok("oke roi do");
        }
    }
}
