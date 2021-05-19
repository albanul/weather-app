using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WeatherApp.BusinessLayer.Interfaces.PresentationLayer;
using WeatherApp.BusinessLayer.Options;

namespace WeatherApp.BusinessLayer.Factories
{
    public class JwtTokenFactory : IJwtTokenFactory
    {
        private readonly IOptions<JwtOptions> _jwtOptions;

        public JwtTokenFactory(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public string CreateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(_jwtOptions.Value.Issuer, expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
