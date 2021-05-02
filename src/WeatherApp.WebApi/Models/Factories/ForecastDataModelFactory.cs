using System.Collections.Generic;
using System.Linq;
using WeatherApp.BusinessLayer.Shared;

namespace WeatherApp.WebApi.Models.Factories
{
    public class ForecastDataModelFactory : IForecastDataModelFactory
    {
        public ForecastDataModel Create(IEnumerable<ForecastData> forecastData)
        {
            if (forecastData == null)
            {
                return new ForecastDataModel();
            }

            return new ForecastDataModel
            {
                Items = forecastData.Select(x => new ForecastDataItemModel
                {
                    Humidity = x.Humidity,
                    Temperature = x.Temperature,
                    WindSpeed = x.WindSpeed,
                    TimeStamp = x.TimeStamp
                })
            };
        }
    }
}
