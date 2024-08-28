using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ChatterBox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public UserController()
        {
        }

        [HttpPost("register")]
        [Authorize]
        public async Task<IActionResult> Register()
        {
            return Ok("");
        }
    }
}
