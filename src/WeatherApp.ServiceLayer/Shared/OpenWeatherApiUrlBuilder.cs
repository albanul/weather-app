using System.Text;

namespace WeatherApp.ServiceLayer.Shared
{
    public class OpenWeatherApiUrlBuilder
    {
        private const string BaseUrl = "https://api.openweathermap.org/data/";
        private string _apiVersion = "2.5";
        private string _endpoint = "forecast";
        private string _units;
        private string _cityName;
        private string _apiKey;
        private string _zipCode;

        public string Build()
        {
            string queryString = GenerateQueryString();

            StringBuilder stringBuilder = new StringBuilder(BaseUrl)
                .Append(_apiVersion)
                .Append('/')
                .Append(_endpoint)
                .Append(queryString);

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

        public OpenWeatherApiUrlBuilder WithUnits(string units)
        {
            _units = units;
            return this;
        }

        public OpenWeatherApiUrlBuilder WithZipCode(string zipCode)
        {
            _zipCode = zipCode;
            return this;
        }

        private string GenerateQueryString()
        {
            var queryStringBuilder = new StringBuilder();

            TryAppendCityName(queryStringBuilder);
            TryAppendZipCode(queryStringBuilder);
            TryAppendApiKey(queryStringBuilder);
            TryAppendUnits(queryStringBuilder);
            HandleFirstSymbol(queryStringBuilder);

            return queryStringBuilder.ToString();
        }

        private void TryAppendCityName(StringBuilder queryStringBuilder)
        {
            TryAppendValue(queryStringBuilder, "q", _cityName);
        }

        private void TryAppendZipCode(StringBuilder queryStringBuilder)
        {
            if (!string.IsNullOrWhiteSpace(_zipCode))
            {
                queryStringBuilder
                    .Append("&zip=")
                    .Append(_zipCode)
                    .Append(",de");
            }
        }

        private void TryAppendApiKey(StringBuilder queryStringBuilder)
        {
            TryAppendValue(queryStringBuilder, "appid", _apiKey);
        }

        private void TryAppendUnits(StringBuilder queryStringBuilder)
        {
            TryAppendValue(queryStringBuilder, "units", _units);
        }

        private void TryAppendValue(StringBuilder queryStringBuilder, string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                queryStringBuilder
                    .Append($"&{key}=")
                    .Append(value);
            }
        }

        private static void HandleFirstSymbol(StringBuilder queryStringBuilder)
        {
            if (queryStringBuilder.Length > 0)
            {
                queryStringBuilder[0] = '?';
            }
        }
    }
}
