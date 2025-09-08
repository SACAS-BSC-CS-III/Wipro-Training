using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureAuthApi.Data;
using SecureAuthApi.DTOs;
using SecureAuthApi.Models;
using SecureAuthApi.Services;

namespace SecureAuthApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IPasswordService _passwords;
    private readonly IJwtTokenService _jwt;
    private readonly ILogger<AuthController> _logger;
    private readonly IGoogleOAuthValidator _google;

    public AuthController(AppDbContext db, IPasswordService passwords, IJwtTokenService jwt,
                          ILogger<AuthController> logger, IGoogleOAuthValidator google)
    {
        _db = db;
        _passwords = passwords;
        _jwt = jwt;
        _logger = logger;
        _google = google;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(new { error = "Invalid input." });

        var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user is null || !_passwords.Verify(request.Password, user.PasswordHash))
        {
            _logger.LogWarning("Failed login attempt for username: {Username}", request.Username);
            return Unauthorized(new { error = "Invalid credentials." });
        }

        var token = _jwt.CreateToken(user);

        return Ok(new AuthResponse
        {
            Token = token,
            Expires_In = 3600,
            User = new { id = user.Id, username = user.Username, roles = user.GetRoleList() }
        });
    }

    [HttpPost("oauth")]
    [AllowAnonymous]
    public async Task<IActionResult> OAuth([FromBody] OAuthRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(new { error = "Invalid input." });

        var (ok, email, name) = await _google.ValidateAsync(request.Token);
        if (!ok || string.IsNullOrWhiteSpace(email))
            return Unauthorized(new { error = "OAuth token validation failed." });

        var username = email.ToLowerInvariant();
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);

        if (user is null)
        {
            user = new ApplicationUser
            {
                Username = username,
                Email = email,
                PasswordHash = _passwords.Hash(Guid.NewGuid().ToString("N")),
                Roles = "User"
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        var token = _jwt.CreateToken(user);

        return Ok(new AuthResponse
        {
            Token = token,
            Expires_In = 3600,
            User = new { id = user.Id, username = user.Username, roles = user.GetRoleList() }
        });
    }
}
