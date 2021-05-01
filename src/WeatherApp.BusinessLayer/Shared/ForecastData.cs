using System;

namespace WeatherApp.BusinessLayer.Shared
{
    public class ForecastData
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
