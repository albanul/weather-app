using System;
using NUnit.Framework;
using WeatherApp.BusinessLayer.Shared;
using WeatherApp.Testing.EqualityComparers;
using WeatherApp.WebApi.Models;
using WeatherApp.WebApi.Models.Factories;

namespace WeatherApp.WebApiTests.Models.Factories
{
    public class ForecastDataModelFactoryTests
    {
        private ForecastDataItemModelEqualityComparer _forecastDataItemModelEqualityComparer;
        private ForecastDataModelFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _forecastDataItemModelEqualityComparer = new ForecastDataItemModelEqualityComparer();
            _factory = new ForecastDataModelFactory();
        }

        [Test]
        public void Create_ShouldReturnEmptyObject_WhenParameterIsNull()
        {
            // act
            ForecastDataModel actual = _factory.Create(null);

            // assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Items, Is.Empty);
        }

        [Test]
        public void Create_ShouldCreateModelCorrectly_ForForecastData()
        {
            // arrange
            DateTime now = DateTime.Now;

            ForecastData[] input =
            {
                CreateForecastData(1.0, now),
                CreateForecastData(2.0, now),
                CreateForecastData(3.0, now)
            };

            ForecastDataItemModel[] expectedItems =
            {
                CreateForecastDataItemModel(1.0, now),
                CreateForecastDataItemModel(2.0, now),
                CreateForecastDataItemModel(3.0, now)
            };

            // act
            ForecastDataModel actual = _factory.Create(input);

            // assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Items, Is.EquivalentTo(expectedItems).Using(_forecastDataItemModelEqualityComparer));
        }

        private static ForecastData CreateForecastData(double value, DateTime timestamp)
        {
            return new()
            {
                Humidity = value,
                Temperature = value,
                TimeStamp = timestamp,
                WindSpeed = value
            };
        }

        private static ForecastDataItemModel CreateForecastDataItemModel(double value, DateTime timestamp)
        {
            return new()
            {
                Humidity = value,
                Temperature = value,
                TimeStamp = timestamp,
                WindSpeed = value
            };
        }
    }
}
