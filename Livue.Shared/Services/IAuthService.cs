namespace Livue.Shared.Services;

public interface IAuthService
{
    bool IsAuthenticated { get; }

    event Action? AuthenticationStateChanged;

    Task<bool> LoginAsync(string username, string password);

    void Logout();
}
