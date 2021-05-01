using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherApp.ServiceLayer.Models
{
    public class OpenWeatherApiResponseModel
    {
        [JsonProperty("cnt")]
        public int Count { get; set; }

        [JsonProperty("list")]
        public IEnumerable<OpenWeatherApiResponseItemModel> Forecasts { get; set; }
    }
}
