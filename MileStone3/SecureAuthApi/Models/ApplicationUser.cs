using System.ComponentModel.DataAnnotations;

namespace SecureAuthApi.Models;

public class ApplicationUser
{
    public int Id { get; set; }

    [Required, MaxLength(64)]
    public string Username { get; set; } = default!;

    [Required]
    public string PasswordHash { get; set; } = default!;

    [Required]
    public string Roles { get; set; } = "User";

    public string? Email { get; set; }

    public IEnumerable<string> GetRoleList() =>
        Roles.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
}
