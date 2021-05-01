using WeatherApp.BusinessLayer.Shared;
using WeatherApp.ServiceLayer.Models;

namespace WeatherApp.ServiceLayer.Factories
{
    public interface IForecastDataFactory
    {
        ForecastData CreateFromOpenWeatherResponse(OpenWeatherApiResponseItemModel model);
    }
}