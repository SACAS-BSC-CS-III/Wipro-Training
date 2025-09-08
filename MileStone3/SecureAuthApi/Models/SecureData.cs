namespace SecureAuthApi.Models;

public class SecureData
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string SecureInfo { get; set; } = default!;
}
