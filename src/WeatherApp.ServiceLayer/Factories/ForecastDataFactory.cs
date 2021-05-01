using System;
using WeatherApp.BusinessLayer.Shared;
using WeatherApp.ServiceLayer.Models;

namespace WeatherApp.ServiceLayer.Factories
{
    public class ForecastDataFactory : IForecastDataFactory
    {
        // TODO ALBA: cover with tests
        public ForecastData CreateFromOpenWeatherResponse(OpenWeatherApiResponseItemModel model)
        {
            DateTime.TryParse(model.TimeStamp, out DateTime timeStamp);

            var forecastData = new ForecastData
            {
                Temperature = model.MainModel.Temperature,
                Humidity = model.MainModel.Humidity,
                WindSpeed = model.WindModel.Speed,
                TimeStamp = timeStamp
            };

            return forecastData;
        }
    }
}
