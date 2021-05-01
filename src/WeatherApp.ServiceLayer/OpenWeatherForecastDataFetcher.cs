using System.Collections.Generic;
using System.Linq;
using WeatherApp.BusinessLayer.Interfaces.ServiceLayer;
using WeatherApp.BusinessLayer.Shared;

namespace WeatherApp.ServiceLayer
{
    public class OpenWeatherForecastDataFetcher : IForecastDataFetcher
    {
        public IEnumerable<ForecastData> FetchDataByCityName(string cityName)
        {
            return Enumerable.Empty<ForecastData>();
        }

        public IEnumerable<ForecastData> FetchDataByZipCode(string zipCode)
        {
            return Enumerable.Empty<ForecastData>();
        }
    }
}
