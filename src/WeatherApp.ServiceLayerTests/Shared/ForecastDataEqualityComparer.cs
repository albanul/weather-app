using System;
using System.Collections.Generic;
using WeatherApp.BusinessLayer.Shared;

namespace WeatherApp.ServiceLayerTests.Shared
{
    public class ForecastDataEqualityComparer : IEqualityComparer<ForecastData>
    {
        public bool Equals(ForecastData x, ForecastData y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Temperature.Equals(y.Temperature) && x.Humidity == y.Humidity && x.WindSpeed.Equals(y.WindSpeed) &&
                   x.TimeStamp.Equals(y.TimeStamp);
        }

        public int GetHashCode(ForecastData obj)
        {
            return HashCode.Combine(obj.Temperature, obj.Humidity, obj.WindSpeed, obj.TimeStamp);
        }
    }
}