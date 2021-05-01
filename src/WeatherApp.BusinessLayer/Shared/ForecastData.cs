using System;

namespace WeatherApp.BusinessLayer.Shared
{
    public class ForecastData
    {
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string WindSpeed { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
