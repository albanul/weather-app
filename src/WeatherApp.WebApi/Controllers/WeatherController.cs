using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Forecast()
        {
            return Ok();
        }
    }
}
