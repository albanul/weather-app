using Newtonsoft.Json;

namespace WeatherApp.ServiceLayer.Models
{
    public class OpenWeatherApiResponseMainModel
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }
}
