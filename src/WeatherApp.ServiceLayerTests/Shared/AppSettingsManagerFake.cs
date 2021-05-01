using Microsoft.Extensions.Configuration;
using WeatherApp.BusinessLayer.Interfaces;
using WeatherApp.BusinessLayer.Interfaces.BusinessLayer;

namespace WeatherApp.ServiceLayerTests.Shared
{
    public class AppSettingsManagerFake : IAppSettingsManager
    {
        private readonly IConfigurationRoot _configuration;

        public AppSettingsManagerFake()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        public string Get(string key)
        {
            return _configuration["OpenWeatherApiKey"];
        }
    }
}
