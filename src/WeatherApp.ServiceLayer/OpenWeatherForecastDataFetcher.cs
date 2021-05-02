using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.BusinessLayer.Interfaces.BusinessLayer;
using WeatherApp.BusinessLayer.Interfaces.ServiceLayer;
using WeatherApp.BusinessLayer.Shared;
using WeatherApp.ServiceLayer.Factories;
using WeatherApp.ServiceLayer.Models;
using WeatherApp.ServiceLayer.Shared;

namespace WeatherApp.ServiceLayer
{
    public class OpenWeatherForecastDataFetcher : IForecastDataFetcher
    {
        private readonly HttpClient _httpClient;
        private readonly IAppSettingsManager _appSettingsManager;
        private readonly IForecastDataFactory _forecastDataFactory;

        public OpenWeatherForecastDataFetcher(
            HttpClient httpClient,
            IAppSettingsManager appSettingsManager,
            IForecastDataFactory forecastDataFactory)
        {
            _httpClient = httpClient;
            _appSettingsManager = appSettingsManager;
            _forecastDataFactory = forecastDataFactory;
        }

        private string ApiKey => _appSettingsManager.Get("OpenWeatherApiKey");

        public async Task<IEnumerable<ForecastData>> FetchDataByCityNameAsync(string cityName)
        {
            string url = new OpenWeatherApiUrlBuilder()
                .WithCityName(cityName)
                .WithApiKey(ApiKey)
                .WithUnits("metric")
                .Build();

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            string json = await response.Content.ReadAsStringAsync();

            List<ForecastData> forecastData = ParseForecastData(json);

            return forecastData;
        }

        public async Task<IEnumerable<ForecastData>> FetchDataByZipCodeAsync(string zipCode)
        {
            return await Task.FromResult(Enumerable.Empty<ForecastData>());
        }

        private List<ForecastData> ParseForecastData(string json)
        {
            var apiResponse = JsonConvert.DeserializeObject<OpenWeatherApiResponseModel>(json);

            List<ForecastData> forecastData = apiResponse?.Forecasts
                .Select(x => _forecastDataFactory.CreateFromOpenWeatherResponse(x))
                .ToList();
            return forecastData;
        }
    }
}
