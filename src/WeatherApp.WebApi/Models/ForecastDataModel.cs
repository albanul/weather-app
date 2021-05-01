using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherApp.WebApi.Models
{
    public class ForecastDataModel
    {
        [JsonPropertyName("items")]
        public IEnumerable<ForecastDataItemModel> Items { get; set; }
    }
}
