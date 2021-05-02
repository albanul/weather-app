using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using WeatherApp.BusinessLayer.Interfaces.BusinessLayer;
using WeatherApp.BusinessLayer.Interfaces.ServiceLayer;
using WeatherApp.BusinessLayer.Managers;
using WeatherApp.BusinessLayer.Shared;

namespace WeatherApp.BusinessLayerTests.Managers
{
    public class ForecastDataManagerTests
    {
        private Mock<IForecastDataFetcher> _forecastDataFetcherMock;
        private Mock<IForecastDataAverageByDayAggregator> _forecastDataAverageByDayAggregator;

        private ForecastDataManager _manager;

        [SetUp]
        public void SetUp()
        {
            _forecastDataFetcherMock = new Mock<IForecastDataFetcher>();
            _forecastDataAverageByDayAggregator = new Mock<IForecastDataAverageByDayAggregator>();

            _manager = new ForecastDataManager(
                _forecastDataFetcherMock.Object,
                _forecastDataAverageByDayAggregator.Object);
        }

        [Test]
        public void GetForecastByCityNameAsync_ShouldReturnEmptyCollection_WhenFetcherThrowsAnError()
        {
            // arrange
            _forecastDataFetcherMock
                .Setup(x => x.FetchDataByCityNameAsync(It.IsAny<string>()))
                .Throws<Exception>();

            // act
            _manager.GetForecastByCityNameAsync("cityName");

            // assert
            _forecastDataAverageByDayAggregator.Verify(x => x.Aggregate(Enumerable.Empty<ForecastData>()), Times.Once);
        }

        [Test]
        public void GetForecastByZipCodeAsync_ShouldReturnEmptyCollection_WhenFetcherThrowsAnError()
        {
            // arrange
            _forecastDataFetcherMock
                .Setup(x => x.FetchDataByZipCodeAsync(It.IsAny<string>()))
                .Throws<Exception>();

            // act
            _manager.GetForecastByZipCodeAsync("zipCode");

            // assert
            _forecastDataAverageByDayAggregator.Verify(x => x.Aggregate(Enumerable.Empty<ForecastData>()), Times.Once);
        }
    }
}
