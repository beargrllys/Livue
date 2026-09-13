namespace Livue.Shared.Services;

/// <summary>
/// A simple in-memory authentication service.
/// Replace with a real authentication implementation as needed.
/// </summary>
public class AuthService : IAuthService
{
    public bool IsAuthenticated { get; private set; }

    public event Action? AuthenticationStateChanged;

    public Task<bool> LoginAsync(string username, string password)
    {
        // TODO: Replace with real authentication logic.
        var success = !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);

        if (success)
        {
            IsAuthenticated = true;
            AuthenticationStateChanged?.Invoke();
        }

        return Task.FromResult(success);
    }

    public void Logout()
    {
        IsAuthenticated = false;
        AuthenticationStateChanged?.Invoke();
    }
}
