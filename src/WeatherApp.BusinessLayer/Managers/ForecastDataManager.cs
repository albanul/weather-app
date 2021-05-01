using System.Collections.Generic;
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
            IEnumerable<ForecastData> rawData = await _forecastDataFetcher.FetchDataByCityNameAsync(cityName);
            IEnumerable<ForecastData> aggregatedData = _forecastDataAverageByDayAggregator.Aggregate(rawData);

            return aggregatedData;
        }

        public Task<IEnumerable<ForecastData>> GetForecastByZipCodeAsync(string cityName)
        {
            throw new System.NotImplementedException();
        }
    }
}
