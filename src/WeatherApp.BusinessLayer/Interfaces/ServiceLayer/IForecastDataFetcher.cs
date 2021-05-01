using System.Collections.Generic;
using WeatherApp.BusinessLayer.Shared;

namespace WeatherApp.BusinessLayer.Interfaces.ServiceLayer
{
    public interface IForecastDataFetcher
    {
        IEnumerable<ForecastData> FetchDataByCityName(string cityName);
        IEnumerable<ForecastData> FetchDataByZipCode(string zipCode);
    }
}
