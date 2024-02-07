using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationPage.Data;
using RegistrationPage.Models;

namespace RegistrationPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthenticationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Login")]
       public IActionResult Login([FromBody]LoginViewModel loginViewModel)
        {
            var user = _context.registrations.SingleOrDefault(u => u.Email == loginViewModel.Username && u.Password == loginViewModel.Password);

            if (user != null)
            {
                return Ok(); // Authentication successful
            }
            else
            {
                return Unauthorized(); // Authentication failed
            }
        }
    }
}

