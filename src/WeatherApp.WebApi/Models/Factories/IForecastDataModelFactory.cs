using System.Collections.Generic;
using WeatherApp.BusinessLayer.Shared;

namespace WeatherApp.WebApi.Models.Factories
{
    public interface IForecastDataModelFactory
    {
        ForecastDataModel Create(string cityName, string zipCode, IEnumerable<ForecastData> forecastData);
    }
}
