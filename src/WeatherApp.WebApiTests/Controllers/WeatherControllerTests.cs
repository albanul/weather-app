using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using WeatherApp.WebApi;
using WeatherApp.WebApi.Models;

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
            HttpResponseMessage response = await client.GetAsync("api/weather/forecast");

            // assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task ForecastEndpoint_ShouldReturnData_WhenCityNameIsMunich()
        {
            // arrange
            var factory = new WebApplicationFactory<Startup>();
            HttpClient client = factory.CreateClient();

            // act
            HttpResponseMessage response = await client.GetAsync("api/weather/forecast?city=Munich");

            // assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            string json = await response.Content.ReadAsStringAsync();

            var model = JsonSerializer.Deserialize<ForecastDataModel>(json);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.Items, Is.Not.Empty);
        }

        [Test]
        public async Task ForecastEndpoint_ShouldReturnData_WhenZipCodeIs80337()
        {
            // arrange
            var factory = new WebApplicationFactory<Startup>();
            HttpClient client = factory.CreateClient();

            // act
            HttpResponseMessage response = await client.GetAsync("api/weather/forecast?zipcode=80337");

            // assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            string json = await response.Content.ReadAsStringAsync();

            var model = JsonSerializer.Deserialize<ForecastDataModel>(json);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.Items, Is.Not.Empty);
        }
    }
}
