using System.ComponentModel.DataAnnotations;

namespace SecureAuthApi.DTOs;

public class LoginRequest
{
    [Required, MinLength(3), MaxLength(64)]
    public string Username { get; set; } = default!;

    [Required, MinLength(8), MaxLength(128)]
    public string Password { get; set; } = default!;
}
