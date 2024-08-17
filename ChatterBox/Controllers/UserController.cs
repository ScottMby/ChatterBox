using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatterBox.Controllers
{
    [ApiController]
    [Route("user/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost("register")]
        [Authorize]
        public async Task Register()
        {
            throw new NotImplementedException();
        }
    }
}
