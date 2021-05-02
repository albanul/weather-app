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

        [JsonPropertyName("items")]
        public IEnumerable<ForecastDataItemModel> Items { get; set; }
    }
}
