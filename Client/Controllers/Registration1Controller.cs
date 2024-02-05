using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RegistrationPage.Models;
using System.Net.Http;
using WebApp.Models;
//using RegistrationPage.Models;


namespace WebApp.Controllers
{
    public class Registration1Controller : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7268/api/");
        private readonly HttpClient _client;

        public Registration1Controller()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet] 
        public IActionResult Index()
        {
            HttpResponseMessage response = _client.GetAsync("Registration/GetRegistrations").Result;
            response.EnsureSuccessStatusCode();

            var registrationsJson = response.Content.ReadAsStringAsync().Result;
            var registrations = JsonConvert.DeserializeObject<IEnumerable<Registration1>>(registrationsJson);

            return View(registrations);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(Registration registration)
        //{
        //    var response = await _client.PostAsJsonAsync("Registration/PostRegistration", registration);
        //    response.EnsureSuccessStatusCode();

        //    return RedirectToAction("Index");
        //}
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registration1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Registration1 reg)
        {
            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync<Registration1>("Registration/PostRegistration", reg);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
              ModelState.AddModelError(string.Empty, "An error occurred while creating the registration.");
                return View(reg);
            }
        }


        // Implement Edit, Details, and Delete actions similarly...

        private async Task<Registration1> GetRegistrationById(int id)
        {
            var response = await _client.GetAsync($"api/Registration/{id}");
            response.EnsureSuccessStatusCode();

            var registrationJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Registration1>(registrationJson);
        }
    }
}

