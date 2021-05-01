using Newtonsoft.Json;

namespace WeatherApp.ServiceLayer.Models
{
    public class OpenWeatherApiResponseItemModel
    {
        [JsonProperty("main")]
        public OpenWeatherApiResponseMainModel MainModel { get; set; }

        [JsonProperty("wind")]
        public OpenWeatherApiResponseWindModel WindModel { get; set; }

        [JsonProperty("dt_txt")]
        public string TimeStamp { get; set; }
    }
}
