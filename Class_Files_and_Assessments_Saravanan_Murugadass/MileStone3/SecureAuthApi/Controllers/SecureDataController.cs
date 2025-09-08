using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using SecureAuthApi.Data;

namespace SecureAuthApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecureDataController : ControllerBase
{
    private readonly AppDbContext _db;

    public SecureDataController(AppDbContext db) => _db = db;

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userIdStr, out var userId))
            return Unauthorized(new { error = "Invalid token." });

        var data = await _db.SecureDatas.AsNoTracking().FirstOrDefaultAsync(d => d.UserId == userId);

        if (data is null)
        {
            return Ok(new
            {
                message = "Secure data accessed successfully.",
                data = new { user_id = userId, secure_info = "No data yet." }
            });
        }

        return Ok(new
        {
            message = "Secure data accessed successfully.",
            data = new { user_id = data.UserId, secure_info = data.SecureInfo }
        });
    }
}
