using System.ComponentModel.DataAnnotations;

namespace SecureAuthApi.DTOs;

public class OAuthRequest
{
    [Required]
    [RegularExpression("google", ErrorMessage = "Only 'google' provider is supported.")]
    public string Provider { get; set; } = default!;

    [Required]
    public string Token { get; set; } = default!;
}
