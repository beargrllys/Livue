using Livue.Shared.Services;

namespace Livue.Services
{
    public class AppSettingsService : IAppSettingsService
    {
        public Task<string?> GetAsync(string key)
        {
            var value = Preferences.Default.Get(key, string.Empty);
            return Task.FromResult(string.IsNullOrEmpty(value) ? null : value);
        }

        public Task SetAsync(string key, string value)
        {
            Preferences.Default.Set(key, value);
            return Task.CompletedTask;
        }
    }
}
