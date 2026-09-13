using Livue.Shared.Services;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Livue.Web.Services
{
    public class AppSettingsService : IAppSettingsService
    {
        private readonly ProtectedLocalStorage _localStorage;

        public AppSettingsService(ProtectedLocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<string?> GetAsync(string key)
        {
            try
            {
                var result = await _localStorage.GetAsync<string>(key);
                return result.Success ? result.Value : null;
            }
            catch
            {
                // Storage is not available yet (e.g. during prerendering).
                return null;
            }
        }

        public async Task SetAsync(string key, string value)
        {
            try
            {
                await _localStorage.SetAsync(key, value);
            }
            catch
            {
                // Ignore if storage is not available (e.g. during prerendering).
            }
        }
    }
}
