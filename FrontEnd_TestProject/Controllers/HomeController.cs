using FrontEnd_TestProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace FrontEnd_TestProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IActionResult CreatetSpecification()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecification(Specifications Specification)
        {
            if (!ModelState.IsValid) return BadRequest("Enter required fields");

            using (var client = new HttpClient())
            {
               
                client.BaseAddress = new Uri("https://localhost:7013/");
                var response = client.PostAsJsonAsync("api/Specification/AddSpecifcation", Specification).Result;
                if (response.IsSuccessStatusCode)
                {
                    return this.Ok("Form Data received!");
                }
                else
                    return this.Ok("ERror");
            }

            return this.Ok("Form Data received!");
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}