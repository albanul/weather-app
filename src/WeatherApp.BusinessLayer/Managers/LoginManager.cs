using System;
using WeatherApp.BusinessLayer.Interfaces.BusinessLayer;
using WeatherApp.BusinessLayer.Interfaces.PresentationLayer;

namespace WeatherApp.BusinessLayer.Managers
{
    public class LoginManager : ILoginManager
    {
        private readonly IJwtTokenFactory _jwtTokenFactory;

        public LoginManager(IJwtTokenFactory jwtTokenFactory)
        {
            _jwtTokenFactory = jwtTokenFactory;
        }

        public string LoginUser(string name, string password)
        {
            if (name == "test" && password == "test")
            {
                return _jwtTokenFactory.CreateToken();
            }

            throw new Exception("Invalid credentials");
        }
    }
}
