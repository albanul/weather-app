using System.Text;

namespace WeatherApp.ServiceLayer.Shared
{
    public class OpenWeatherApiUrlBuilder
    {
        private const string BaseUrl = "https://api.openweathermap.org/data/";
        private string _apiVersion = "2.5";
        private string _endpoint = "forecast";
        private string _cityName;
        private string _apiKey;

        public string Build()
        {
            StringBuilder stringBuilder = new StringBuilder(BaseUrl)
                .Append(_apiVersion)
                .Append('/')
                .Append(_endpoint);

            var queryStringBuilder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(_cityName))
            {
                queryStringBuilder
                    .Append("&q=")
                    .Append(_cityName);
            }

            if (!string.IsNullOrWhiteSpace(_apiKey))
            {
                queryStringBuilder
                    .Append("&appid=")
                    .Append(_apiKey);
            }

            if (queryStringBuilder.Length > 0)
            {
                queryStringBuilder[0] = '?';
                stringBuilder.Append(queryStringBuilder);
            }

            return stringBuilder.ToString();
        }

        public OpenWeatherApiUrlBuilder WithApiVersion(string apiVersion)
        {
            _apiVersion = apiVersion;
            return this;
        }

        public OpenWeatherApiUrlBuilder WithCityName(string cityName)
        {
            _cityName = cityName;
            return this;
        }

        public OpenWeatherApiUrlBuilder WithApiKey(string apiKey)
        {
            _apiKey = apiKey;
            return this;
        }
    }
}
