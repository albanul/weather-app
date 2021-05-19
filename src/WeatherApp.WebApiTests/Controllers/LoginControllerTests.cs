// unset

using System.Collections.Generic;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherApp.WebApi.Models;

namespace WeatherApp.WebApiTests.Controllers
{
    using Microsoft.AspNetCore.Mvc.Testing;
    using NUnit.Framework;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using WebApi;

    public class LoginControllerTests
    {
        [Test]
        public async Task Login_ShouldReturnUnauthorized_WhenInvalidCredentials()
        {
            // arrange
            var factory = new WebApplicationFactory<Startup>();
            HttpClient client = factory.CreateClient();

            // act
            var userModel = new UserModel {Name = "bla", Password = "bla"};

            HttpResponseMessage response = await client.PostAsJsonAsync("api/login", userModel);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [Test]
        public async Task Login_ShouldReturnToken_WhenCredentialsAreValid()
        {
            // arrange
            var factory = new WebApplicationFactory<Startup>();
            HttpClient client = factory.CreateClient();

            // act
            var userModel = new UserModel {Name = "test", Password = "test"};

            HttpResponseMessage response = await client.PostAsJsonAsync("api/login", userModel);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            string content = await response.Content.ReadAsStringAsync();
            var jObj = JObject.Parse(content);

            string token = jObj["token"]?.Value<string>();

            Assert.That(token, Is.Not.Empty);
        }
    }
}
