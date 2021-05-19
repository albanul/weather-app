using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.BusinessLayer.Interfaces.BusinessLayer;
using WeatherApp.BusinessLayer.Shared;
using WeatherApp.WebApi.Models;
using WeatherApp.WebApi.Models.Factories;

namespace WeatherApp.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class WeatherController : Controller
    {
        private readonly IForecastDataManager _forecastDataManager;
        private readonly IForecastDataModelFactory _forecastDataModelFactory;

        public WeatherController(
            IForecastDataManager forecastDataManager,
            IForecastDataModelFactory forecastDataModelFactory)
        {
            _forecastDataManager = forecastDataManager;
            _forecastDataModelFactory = forecastDataModelFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Forecast(string city, string zipCode)
        {
            ForecastDataModel model;

            if (!string.IsNullOrWhiteSpace(city))
            {
                List<ForecastData> forecastData =
                    (await _forecastDataManager.GetForecastByCityNameAsync(city)).ToList();

                model = _forecastDataModelFactory.Create(city, zipCode, forecastData);
                return Ok(model);
            }

            if (!string.IsNullOrWhiteSpace(zipCode))
            {
                List<ForecastData> forecastData =
                    (await _forecastDataManager.GetForecastByZipCodeAsync(zipCode)).ToList();

                model = _forecastDataModelFactory.Create(city, zipCode, forecastData);
                return Ok(model);
            }

            model = new ForecastDataModel();

            return Ok(model);
        }
    }
}
