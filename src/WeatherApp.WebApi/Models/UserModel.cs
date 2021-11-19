using System.ComponentModel.DataAnnotations;

namespace WeatherApp.WebApi.Models
{
    public class UserModel
    {
        [Required]
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
