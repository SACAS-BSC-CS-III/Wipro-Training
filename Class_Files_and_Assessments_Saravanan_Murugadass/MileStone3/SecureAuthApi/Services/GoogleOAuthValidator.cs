

namespace SecureAuthApi.Services
{
    public class GoogleOptions
    {
        public string ClientId { get; set; } = default!;
        public string Audience { get; set; } = default!;
    }

    public interface IGoogleOAuthValidator
    {

        Task<(bool ok, string? email, string? name)> ValidateAsync(string idToken);
    }

    public class GoogleOAuthValidator : IGoogleOAuthValidator
    {
        public Task<(bool ok, string? email, string? name)> ValidateAsync(string idToken)
        {
            return Task.FromResult((true, "google_user@example.com", "Google User"));
        }
    }
}
