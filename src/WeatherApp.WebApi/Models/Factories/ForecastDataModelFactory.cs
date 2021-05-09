using System.Collections.Generic;
using System.Linq;
using WeatherApp.BusinessLayer.Shared;

namespace WeatherApp.WebApi.Models.Factories
{
    public class ForecastDataModelFactory : IForecastDataModelFactory
    {
        public ForecastDataModel Create(string cityName, string zipCode, IEnumerable<ForecastData> forecastData)
        {
            if (forecastData == null)
            {
                return new ForecastDataModel();
            }

            return new ForecastDataModel
            {
                CityName = cityName,
                ZipCode = zipCode,
                Items = forecastData.Select(x => new ForecastDataItemModel
                {
                    Humidity = x.Humidity,
                    Temperature = x.Temperature,
                    WindSpeed = x.WindSpeed,
                    Date = x.TimeStamp
                })
            };
        }
    }
}
