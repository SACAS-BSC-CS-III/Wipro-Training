namespace SecureAuthApi.DTOs;

public class AuthResponse
{
    public string Token { get; set; } = default!;
    public int Expires_In { get; set; }
    public object User { get; set; } = default!;
}
