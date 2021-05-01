using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using WeatherApp.WebApi;

namespace WeatherApp.WebApiTests.Controllers
{
    public class WeatherControllerTests
    {
        [Test]
        public async Task ForecastEndpointShouldReturnOk()
        {
            // arrange
            var factory = new WebApplicationFactory<Startup>();
            HttpClient client = factory.CreateClient();

            // act
            HttpResponseMessage response = await client.GetAsync("api/weather");

            // assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
