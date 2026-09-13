using System.Globalization;

namespace Livue.Shared.Services;

public interface ICultureService
{
    CultureInfo CurrentCulture { get; }

    IReadOnlyList<CultureInfo> SupportedCultures { get; }

    event Action? CultureChanged;

    /// <summary>
    /// Loads a previously saved language preference, if any.
    /// Returns true if a saved preference was found and applied.
    /// </summary>
    Task<bool> TryRestoreSavedCultureAsync();

    /// <summary>
    /// Sets the current culture and persists the choice for future launches.
    /// </summary>
    Task SetCultureAsync(string cultureName);

    void SetCulture(string cultureName);
}
