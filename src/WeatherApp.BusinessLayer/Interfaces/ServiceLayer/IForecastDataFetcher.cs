using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.BusinessLayer.Shared;

namespace WeatherApp.BusinessLayer.Interfaces.ServiceLayer
{
    public interface IForecastDataFetcher
    {
        Task<IEnumerable<ForecastData>> FetchDataByCityNameAsync(string cityName);
        Task<IEnumerable<ForecastData>> FetchDataByZipCodeAsync(string zipCode);
    }
}
