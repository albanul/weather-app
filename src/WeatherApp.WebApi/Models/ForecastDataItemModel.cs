using System;
using System.Text.Json.Serialization;

namespace WeatherApp.WebApi.Models
{
    public class ForecastDataItemModel
    {
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }

        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }

        [JsonPropertyName("windSpeed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}
