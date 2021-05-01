using Newtonsoft.Json;

namespace WeatherApp.ServiceLayer.Models
{
    public class OpenWeatherApiResponseWindModel
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
    }
}