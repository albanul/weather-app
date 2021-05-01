using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.BusinessLayer.Interfaces.BusinessLayer;
using WeatherApp.BusinessLayer.Shared;
using WeatherApp.WebApi.Models;

namespace WeatherApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherController : Controller
    {
        private readonly IForecastDataManager _forecastDataManager;

        public WeatherController(IForecastDataManager forecastDataManager)
        {
            _forecastDataManager = forecastDataManager;
        }

        [HttpGet]
        public async Task<IActionResult> Forecast(string city)
        {
            List<ForecastData> forecastData =
                (await _forecastDataManager.GetForecastByCityNameAsync(city)).ToList();

            var model = new ForecastDataModel
            {
                Items = forecastData.Select(x => new ForecastDataItemModel
                {
                    Humidity = x.Humidity,
                    Temperature = x.Temperature,
                    WindSpeed = x.WindSpeed,
                    TimeStamp = x.TimeStamp
                })
            };

            return Ok(model);
        }
    }
}
