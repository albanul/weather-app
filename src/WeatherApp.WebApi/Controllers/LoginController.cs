using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.BusinessLayer.Interfaces.BusinessLayer;
using WeatherApp.WebApi.Models;

namespace WeatherApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginManager _loginManager;

        public LoginController(ILoginManager loginManager)
        {
            _loginManager = loginManager;
        }

        [HttpPost("")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserModel userModel)
        {
            if (userModel == null)
            {
                return Unauthorized();
            }

            string token;

            try
            {
                token = _loginManager.LoginUser(userModel.Name, userModel.Password);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            return Ok(new {token});
        }
    }
}
