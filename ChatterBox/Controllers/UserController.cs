using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatterBox.Controllers
{
    [ApiController]
    [Route("user/[controller]")]
    public class UserController : Controller
    {
        public UserController()
        {
        }

        [HttpPost("register")]
        [Authorize]
        public async Task<IActionResult> Register()
        {
            throw new NotImplementedException();
        }
    }
}
