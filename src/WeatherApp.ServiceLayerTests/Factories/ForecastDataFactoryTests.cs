using System;
using NUnit.Framework;
using WeatherApp.BusinessLayer.Shared;
using WeatherApp.ServiceLayer.Factories;
using WeatherApp.ServiceLayer.Models;
using WeatherApp.Testing.EqualityComparers;

namespace WeatherApp.ServiceLayerTests.Factories
{
    public class ForecastDataFactoryTests
    {
        private ForecastDataFactory _factory;
        private ForecastDataEqualityComparer _equalityComparer;

        [SetUp]
        public void SetUp()
        {
            _factory = new ForecastDataFactory();

            _equalityComparer = new ForecastDataEqualityComparer();
        }

        [TestCase(10.0, 10, 10.0, "2021-05-01 21:00:00")]
        [TestCase(125.13, 99, .7, "2021-05-03 09:00:00")]
        [TestCase(0.0, 54, 13.123, "2000-05-01 18:34:10")]
        public void CreateFromOpenWeatherResponse_ShouldCreateCorrectForecastData(double temperature, int humidity,
            double windSpeed, string timestamp)
        {
            // arrange
            var model = new OpenWeatherApiResponseItemModel
            {
                MainModel = new OpenWeatherApiResponseMainModel
                {
                    Temperature = temperature,
                    Humidity = humidity
                },
                WindModel = new OpenWeatherApiResponseWindModel
                {
                    Speed = windSpeed
                },
                TimeStamp = timestamp
            };

            DateTime timestampDatetime = DateTime.Parse(timestamp);

            var expected = new ForecastData
            {
                Humidity = humidity,
                Temperature = temperature,
                TimeStamp = timestampDatetime,
                WindSpeed = windSpeed
            };

            // act
            ForecastData actual = _factory.CreateFromOpenWeatherResponse(model);

            // assert
            Assert.That(actual, Is.EqualTo(expected).Using(_equalityComparer));
        }
    }
}
