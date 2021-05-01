using Microsoft.Extensions.Configuration;
using WeatherApp.BusinessLayer.Interfaces.BusinessLayer;

namespace WeatherApp.WebApi.Shared
{
    public class AppSettingsManager : IAppSettingsManager
    {
        private readonly IConfiguration _configuration;

        public AppSettingsManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Get(string key)
        {
            return _configuration[key];
        }
    }
}
