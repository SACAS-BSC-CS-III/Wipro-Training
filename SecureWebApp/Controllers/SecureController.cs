using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [HttpGet("user")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult GetUserData()
        {
            return Ok("This is secured data for Users and Admins.");
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminData()
        {
            return Ok("This is secured data for Admins only.");
        }
    }
}
