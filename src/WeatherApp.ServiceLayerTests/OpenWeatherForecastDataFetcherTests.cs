using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using WeatherApp.BusinessLayer.Shared;
using WeatherApp.ServiceLayer;
using WeatherApp.ServiceLayer.Factories;
using WeatherApp.ServiceLayerTests.Shared;

namespace WeatherApp.ServiceLayerTests
{
    public class OpenWeatherForecastDataFetcherTests
    {
        private HttpClient _httpClient;
        private OpenWeatherForecastDataFetcher _fetcher;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
            var appSettingManager = new AppSettingsManagerFake();
            var forecastDataFactory = new ForecastDataFactory();

            _fetcher = new OpenWeatherForecastDataFetcher(_httpClient, appSettingManager, forecastDataFactory);
        }

        [TearDown]
        public void TearDown()
        {
            _httpClient.Dispose();
        }

        [Test]
        public async Task FetchDataByCityName_ShouldCorrectlyFetchDataForMunich()
        {
            // arrange
            const string cityName = "Munich";

            // act
            List<ForecastData> forecastData = (await _fetcher.FetchDataByCityNameAsync(cityName)).ToList();

            // assert
            Assert.That(forecastData, Is.Not.Empty);
        }
    }
}
