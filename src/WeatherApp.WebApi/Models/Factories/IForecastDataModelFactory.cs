using System.Collections.Generic;
using WeatherApp.BusinessLayer.Shared;

namespace WeatherApp.WebApi.Models.Factories
{
    public interface IForecastDataModelFactory
    {
        ForecastDataModel Create(IEnumerable<ForecastData> forecastData);
    }
}