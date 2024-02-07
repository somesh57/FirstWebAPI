using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _client;

        public LoginController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7268/api/");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel1 model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            HttpResponseMessage response = await _client.PostAsJsonAsync("Authentication/Login", model);
            if (response.IsSuccessStatusCode)
            {
                // Authentication successful, redirect to dashboard or home page
                return RedirectToAction("Index", "Registration1");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View(model);
            }
        }
    }
}