using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class LoginViewModel1
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
