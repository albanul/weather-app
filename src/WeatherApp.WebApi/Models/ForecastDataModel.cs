using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace WeatherApp.WebApi.Models
{
    public class ForecastDataModel
    {
        public ForecastDataModel()
        {
            Items = Enumerable.Empty<ForecastDataItemModel>();
        }

        [JsonPropertyName("cityName")]
        public string CityName { get; set; }

        [JsonPropertyName("zipCode")]
        public string ZipCode { get; set; }

        [JsonPropertyName("items")]
        public IEnumerable<ForecastDataItemModel> Items { get; set; }
    }
}
