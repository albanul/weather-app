using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WeatherApp.BusinessLayer.Shared;
using WeatherApp.ServiceLayer;

namespace WeatherApp.ServiceLayerTests
{
    public class OpenWeatherForecastDataFetcherTests
    {
        private OpenWeatherForecastDataFetcher _fetcher;

        [SetUp]
        public void Setup()
        {
            _fetcher = new OpenWeatherForecastDataFetcher();
        }

        [Test]
        public void FetchDataByCityName_ShouldCorrectlyFetchDataForMunich()
        {
            // arrange
            const string cityName = "Munich";

            // act
            List<ForecastData> forecastData = _fetcher.FetchDataByCityName(cityName).ToList();

            // assert
            Assert.That(forecastData, Is.Not.Empty);
        }
    }
}
