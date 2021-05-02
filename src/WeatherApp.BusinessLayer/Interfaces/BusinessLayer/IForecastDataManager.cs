using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.BusinessLayer.Shared;

namespace WeatherApp.BusinessLayer.Interfaces.BusinessLayer
{
    public interface IForecastDataManager
    {
        Task<IEnumerable<ForecastData>> GetForecastByCityNameAsync(string cityName);
        Task<IEnumerable<ForecastData>> GetForecastByZipCodeAsync(string zipCode);
    }
}
