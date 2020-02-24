using Microsoft.Extensions.Configuration;

namespace WebApplication.Data
{
    public class AppSettingsService
    {
        private readonly IConfiguration _config;
        public AppSettingsService(IConfiguration config)
        {
            _config = config;
        }
        public string GetBaseUrl()
        {
            return _config.GetValue<string>("DatabaseCrudApi:BaseUrl");
        }
    }
}
