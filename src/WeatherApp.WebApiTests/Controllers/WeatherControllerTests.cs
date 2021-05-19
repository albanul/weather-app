using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using WeatherApp.WebApi;
using WeatherApp.WebApi.Models;

namespace WeatherApp.WebApiTests.Controllers
{
    public class WeatherControllerTests
    {
        [Test]
        public async Task ForecastEndpointShouldReturnUnauthorized_WhenNoToken()
        {
            // arrange
            var factory = new WebApplicationFactory<Startup>();
            HttpClient client = factory.CreateClient();

            // act
            HttpResponseMessage response = await client.GetAsync("api/weather/forecast?city=Munich");

            // assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [Test]
        public async Task ForecastEndpointShouldReturnOk()
        {
            // arrange
            HttpClient client = await GetHttpClientWithFilledTokenAsync();

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
            HttpClient client = await GetHttpClientWithFilledTokenAsync();

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
            HttpClient client = await GetHttpClientWithFilledTokenAsync();

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

        private static async Task<HttpClient> GetHttpClientWithFilledTokenAsync()
        {
            var factory = new WebApplicationFactory<Startup>();
            HttpClient client = factory.CreateClient();

            string token = await GetJwtToken(client);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return client;
        }

        private static async Task<string> GetJwtToken(HttpClient client)
        {
            var userModel = new UserModel {Name = "test", Password = "test"};
            HttpResponseMessage response = await client.PostAsJsonAsync("api/login", userModel);

            string content = await response.Content.ReadAsStringAsync();
            var jObj = JObject.Parse(content);

            string token = jObj["token"]?.Value<string>();
            return token;
        }
    }
}
