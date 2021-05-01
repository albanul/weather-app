using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WeatherApp.BusinessLayer.Aggregators;
using WeatherApp.BusinessLayer.Shared;
using WeatherApp.Testing.EqualityComparers;

namespace WeatherApp.BusinessLayerTests.Aggregators
{
    public class ForecastDataAverageByDayAggregatorTests
    {
        private ForecastDataAverageByDayAggregator _aggregator;
        private ForecastDataEqualityComparer _equalityComparer;

        [SetUp]
        public void SetUp()
        {
            _aggregator = new ForecastDataAverageByDayAggregator();

            _equalityComparer = new ForecastDataEqualityComparer();
        }

        [Test]
        public void Aggregate_ShouldReturnAggregatedByDayData_ForOneDay()
        {
            // arrange
            DateTime now = DateTime.Now;

            var input = new List<ForecastData>
            {
                new()
                {
                    Humidity = 1,
                    Temperature = 1,
                    WindSpeed = 1,
                    TimeStamp = now
                },

                new()
                {
                    Humidity = 2,
                    Temperature = 2,
                    WindSpeed = 2,
                    TimeStamp = now
                },

                new()
                {
                    Humidity = 3,
                    Temperature = 3,
                    WindSpeed = 3,
                    TimeStamp = now
                }
            };


            var expected = new List<ForecastData>
            {
                new()
                {
                    Humidity = 2,
                    Temperature = 2,
                    WindSpeed = 2,
                    TimeStamp = now.Date
                }
            };

            // act
            List<ForecastData> actual = _aggregator.Aggregate(input).ToList();

            // assert
            Assert.That(actual, Is.EquivalentTo(expected).Using(_equalityComparer));
        }

        [Test]
        public void Aggregate_ShouldReturnAggregatedByDayData_ForOneDayWithDifferentValues()
        {
            // arrange
            DateTime now = DateTime.Now;

            var input = new List<ForecastData>
            {
                new()
                {
                    Humidity = 1,
                    Temperature = 2,
                    WindSpeed = 3,
                    TimeStamp = now
                },

                new()
                {
                    Humidity = 1,
                    Temperature = 2,
                    WindSpeed = 3,
                    TimeStamp = now
                },

                new()
                {
                    Humidity = 1,
                    Temperature = 2,
                    WindSpeed = 3,
                    TimeStamp = now
                }
            };


            var expected = new List<ForecastData>
            {
                new()
                {
                    Humidity = 1,
                    Temperature = 2,
                    WindSpeed = 3,
                    TimeStamp = now.Date
                }
            };

            // act
            List<ForecastData> actual = _aggregator.Aggregate(input).ToList();

            // assert
            Assert.That(actual, Is.EquivalentTo(expected).Using(_equalityComparer));
        }

        [Test]
        public void Aggregate_ShouldReturnAggregatedByDayData_ForTwoDaysWithDifferentValues()
        {
            // arrange
            DateTime now = DateTime.Now;

            var input = new List<ForecastData>
            {
                new()
                {
                    Humidity = 1,
                    Temperature = 2,
                    WindSpeed = 3,
                    TimeStamp = now
                },

                new()
                {
                    Humidity = 1,
                    Temperature = 2,
                    WindSpeed = 3,
                    TimeStamp = now
                },

                new()
                {
                    Humidity = 2,
                    Temperature = 4,
                    WindSpeed = 8,
                    TimeStamp = now.AddDays(1)
                }
            };


            var expected = new List<ForecastData>
            {
                new()
                {
                    Humidity = 1,
                    Temperature = 2,
                    WindSpeed = 3,
                    TimeStamp = now.Date
                },
                new()
                {
                    Humidity = 2,
                    Temperature = 4,
                    WindSpeed = 8,
                    TimeStamp = now.AddDays(1).Date
                }
            };

            // act
            List<ForecastData> actual = _aggregator.Aggregate(input).ToList();

            // assert
            Assert.That(actual, Is.EquivalentTo(expected).Using(_equalityComparer));
        }
    }
}
