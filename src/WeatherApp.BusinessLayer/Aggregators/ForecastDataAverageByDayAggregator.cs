using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.BusinessLayer.Interfaces.BusinessLayer;
using WeatherApp.BusinessLayer.Shared;

namespace WeatherApp.BusinessLayer.Aggregators
{
    public class ForecastDataAverageByDayAggregator : IForecastDataAggregator
    {
        public IEnumerable<ForecastData> Aggregate(IEnumerable<ForecastData> data)
        {
            List<ForecastData> averageValues = data
                .GroupBy(x => x.TimeStamp.Date)
                .Select(CreateAverageForecastData)
                .ToList();

            return averageValues;
        }

        private static ForecastData CreateAverageForecastData(IGrouping<DateTime, ForecastData> grouping)
        {
            var forecastData = new ForecastData
            {
                Humidity = grouping.Average(x => x.Humidity),
                Temperature = grouping.Average(x => x.Temperature),
                WindSpeed = grouping.Average(x => x.WindSpeed),
                TimeStamp = grouping.Key
            };

            return forecastData;
        }
    }
}
