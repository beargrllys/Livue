using System.Globalization;

namespace Livue.Shared.Services;

/// <summary>
/// Tracks the current UI culture and notifies subscribers when it changes.
/// Works for both the MAUI BlazorWebView (in-process) and Blazor Web (per-circuit) hosts.
/// </summary>
public class CultureService : ICultureService
{
    private const string StorageKey = "livue.culture";

    private readonly IAppSettingsService _appSettings;

    public CultureService(IAppSettingsService appSettings)
    {
        _appSettings = appSettings;
    }

    public static readonly CultureInfo[] AllSupportedCultures =
    {
        new("ko"),
        new("en"),
        new("zh"),
        new("ja"),
    };

    public CultureInfo CurrentCulture { get; private set; } = CultureInfo.CurrentUICulture;

    public IReadOnlyList<CultureInfo> SupportedCultures => AllSupportedCultures;

    public event Action? CultureChanged;

    public async Task<bool> TryRestoreSavedCultureAsync()
    {
        var savedCultureName = await _appSettings.GetAsync(StorageKey);

        if (string.IsNullOrEmpty(savedCultureName))
        {
            return false;
        }

        SetCulture(savedCultureName);
        return true;
    }

    public async Task SetCultureAsync(string cultureName)
    {
        SetCulture(cultureName);
        await _appSettings.SetAsync(StorageKey, cultureName);
    }

    public void SetCulture(string cultureName)
    {
        var culture = new CultureInfo(cultureName);

        if (CurrentCulture.Name == culture.Name)
        {
            return;
        }

        CurrentCulture = culture;
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;

        // Ensure the culture also applies to any new threads spawned by the
        // Blazor render pipeline (Server circuits and MAUI BlazorWebView both
        // dispatch continuations on threads that don't automatically inherit
        // the culture set above via ExecutionContext flow).
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;

        CultureChanged?.Invoke();
    }
}
