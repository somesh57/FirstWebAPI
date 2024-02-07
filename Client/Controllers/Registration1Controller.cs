using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RegistrationPage.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Models;

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

        public ActionResult Create()
        {
            return View();
        }

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

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var registration = await GetRegistrationById(id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Registration1 reg)
        {
            try
            {
                
                    HttpResponseMessage response = await _client.PutAsJsonAsync($"Registration/PutRegistration/{id}", reg);
                    response.EnsureSuccessStatusCode();
                    return RedirectToAction("Index");
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the registration.");
                return View(reg);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var registration = await GetRegistrationById(id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var registration = await GetRegistrationById(id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync($"Registration/DeleteRegistration/{id}");
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the registration.");
                return RedirectToAction("Delete", new { id });
            }
        }

        private async Task<Registration1> GetRegistrationById(int id)
        {
            var response = await _client.GetAsync($"Registration/GetRegistration/{id}");
            response.EnsureSuccessStatusCode();

            var registrationJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Registration1>(registrationJson);
        }
    }
}
