using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using WeatherApp.BusinessLayer.Factories;
using WeatherApp.BusinessLayer.Options;

namespace WeatherApp.WebApiTests.Factories
{
    public class JwtTokenFactoryTests
    {
        private JwtTokenFactory _factory;

        [SetUp]
        public void SetUp()
        {
            var options = new Mock<IOptions<JwtOptions>>();
            _factory = new JwtTokenFactory(options.Object);

            options.Setup(x => x.Value).Returns(new JwtOptions {Key = "verylongkeyqwerty", Issuer = "Issuer"});
        }

        [Test]
        public void CreateToken_ShouldCreateNonEmptyToken()
        {
            // act
            string actual = _factory.CreateToken();

            // assert
            Assert.That(actual, Is.Not.Empty);
        }
    }
}
