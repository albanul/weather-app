using System;
using System.Collections.Generic;
using WeatherApp.WebApi.Models;

namespace WeatherApp.Testing.EqualityComparers
{
    public class ForecastDataItemModelEqualityComparer : IEqualityComparer<ForecastDataItemModel>
    {
        public bool Equals(ForecastDataItemModel x, ForecastDataItemModel y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Temperature.Equals(y.Temperature) && x.Humidity.Equals(y.Humidity) &&
                   x.WindSpeed.Equals(y.WindSpeed) && x.Date.Equals(y.Date);
        }

        public int GetHashCode(ForecastDataItemModel obj)
        {
            return HashCode.Combine(obj.Temperature, obj.Humidity, obj.WindSpeed, obj.Date);
        }
    }
}
