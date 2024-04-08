using BusinessLogic.Token;
using BussinessLogic.IService;
using Microsoft.AspNetCore.Mvc;

namespace PRN231PE_FA23_665511_SE162088.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class BrandAccountController : Controller
    {
        IBranchAccountService _user;
        IConfiguration _config;

        public BrandAccountController(IBranchAccountService user, IConfiguration config)
        {
            _user = user;
            _config = config ?? throw new ArgumentNullException(nameof(config));
            ProvideToken.Initialize(_config);
        }

        [HttpPost("login")]
        public IActionResult Login(string Email, string password)
        {
            var checkLogin = _user.Login(Email, password);
            if (checkLogin != null)
            {
                var token = ProvideToken.Instance.GenerateToken(checkLogin);
                return Ok(token);
            }
            return Unauthorized("Email or password wrong, please try login!");
        }
    }
}