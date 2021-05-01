using System.Collections.Generic;
using WeatherApp.BusinessLayer.Shared;

namespace WeatherApp.BusinessLayer.Interfaces.BusinessLayer
{
    public interface IForecastDataAggregator
    {
        public IEnumerable<ForecastData> Aggregate(IEnumerable<ForecastData> data);
    }
}
