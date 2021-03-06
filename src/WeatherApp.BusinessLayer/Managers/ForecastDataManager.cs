using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.BusinessLayer.Interfaces.BusinessLayer;
using WeatherApp.BusinessLayer.Interfaces.ServiceLayer;
using WeatherApp.BusinessLayer.Shared;

namespace WeatherApp.BusinessLayer.Managers
{
    public class ForecastDataManager : IForecastDataManager
    {
        private readonly IForecastDataFetcher _forecastDataFetcher;
        private readonly IForecastDataAverageByDayAggregator _forecastDataAverageByDayAggregator;

        public ForecastDataManager(
            IForecastDataFetcher forecastDataFetcher,
            IForecastDataAverageByDayAggregator forecastDataAverageByDayAggregator)
        {
            _forecastDataFetcher = forecastDataFetcher;
            _forecastDataAverageByDayAggregator = forecastDataAverageByDayAggregator;
        }

        public async Task<IEnumerable<ForecastData>> GetForecastByCityNameAsync(string cityName)
        {
            IEnumerable<ForecastData> rawData;

            try
            {
                rawData = await _forecastDataFetcher.FetchDataByCityNameAsync(cityName);
            }
            catch (Exception)
            {
                rawData = Enumerable.Empty<ForecastData>();
            }

            IEnumerable<ForecastData> aggregatedData = _forecastDataAverageByDayAggregator.Aggregate(rawData);

            return aggregatedData;
        }

        public async Task<IEnumerable<ForecastData>> GetForecastByZipCodeAsync(string zipCode)
        {
            IEnumerable<ForecastData> rawData;

            try
            {
                rawData = await _forecastDataFetcher.FetchDataByZipCodeAsync(zipCode);
            }
            catch (Exception)
            {
                rawData = Enumerable.Empty<ForecastData>();
            }

            IEnumerable<ForecastData> aggregatedData = _forecastDataAverageByDayAggregator.Aggregate(rawData);

            return aggregatedData;
        }
    }
}
