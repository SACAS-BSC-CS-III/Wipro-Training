using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureDatabaseApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [HttpGet("user")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult GetUserData()
        {
            return Ok("Secure data for authenticated Users and Admins.");
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminData()
        {
            return Ok("Secure data for Admins only.");
        }
    }
}
