namespace Livue.Shared.Services;

/// <summary>
/// Simple key-value persistence abstraction, implemented per host
/// (MAUI uses Microsoft.Maui.Storage.Preferences, Web uses browser storage).
/// </summary>
public interface IAppSettingsService
{
    Task<string?> GetAsync(string key);

    Task SetAsync(string key, string value);
}
