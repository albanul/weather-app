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
            string mySecret = _jwtOptions.Value.Key;
            var mySecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mySecret));

            string myIssuer = _jwtOptions.Value.Issuer;
            string myAudience = _jwtOptions.Value.Audience;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = myIssuer,
                Audience = myAudience,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
