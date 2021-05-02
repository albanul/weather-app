using NUnit.Framework;
using WeatherApp.ServiceLayer.Shared;

namespace WeatherApp.ServiceLayerTests.Shared
{
    public class OpenWeatherApiUrlBuilderTests
    {
        private OpenWeatherApiUrlBuilder _builder;

        [SetUp]
        public void SetUp()
        {
            _builder = new OpenWeatherApiUrlBuilder();
        }

        [Test]
        public void Build_ShouldReturnUrl_ByDefault()
        {
            // arrange
            const string expected = "https://api.openweathermap.org/data/2.5/forecast";

            // act
            string actual = _builder.Build();

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("3")]
        [TestCase("2.5")]
        [TestCase("1")]
        public void Build_ShouldReturnCorrectUrl_WhenApiVersionIsDifferent(string apiVersion)
        {
            // arrange
            var expected = $"https://api.openweathermap.org/data/{apiVersion}/forecast";

            // act
            string actual = _builder.WithApiVersion(apiVersion).Build();

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("Munich")]
        [TestCase("Moscow")]
        [TestCase("London")]
        public void Build_ShouldReturnCorrectUrl_WhenCityNameIsSet(string cityName)
        {
            // arrange
            string expected = "https://api.openweathermap.org/data/2.5/forecast?q=" + cityName;

            // act
            string actual = _builder.WithCityName(cityName).Build();

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("foo")]
        [TestCase("bar")]
        [TestCase("baz")]
        public void Build_ShouldReturnCorrectUrl_WhenApiKeyIsSet(string apiKey)
        {
            // arrange
            string expected = "https://api.openweathermap.org/data/2.5/forecast?appid=" + apiKey;

            // act
            string actual = _builder.WithApiKey(apiKey).Build();

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("Munich", "foo")]
        [TestCase("Moscow", "bar")]
        [TestCase("London", "baz")]
        public void Build_ShouldReturnCorrectUrl_WhenBothCityAndApiKeyAreSet(string cityName, string apiKey)
        {
            // arrange
            var expected = $"https://api.openweathermap.org/data/2.5/forecast?q={cityName}&appid={apiKey}";

            // act
            string actual = _builder.WithCityName(cityName).WithApiKey(apiKey).Build();

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("metric")]
        [TestCase("standard")]
        [TestCase("imperial")]
        public void Build_ShouldReturnCorrectUrl_WhenUnitsAreSet(string units)
        {
            // arrange
            var expected = $"https://api.openweathermap.org/data/2.5/forecast?units={units}";

            // act
            string actual = _builder.WithUnits(units).Build();

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
