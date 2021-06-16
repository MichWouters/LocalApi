using LocalClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using LocalClient.Services;

namespace LocalClient.Controllers
{
    [Authorize]
    public class WeatherForecastsController : Controller
    {
        private IWeatherForecastService _service;
        public WeatherForecastsController(IWeatherForecastService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetForecasts();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([Bind("Id,Date,TemperatureC,Summary")] WeatherForecast weatherForecast)
        {
            if (User.Identity == null) { throw new AuthenticationException("User is not authenticated"); }
            if (!ModelState.IsValid) { return View(weatherForecast); }

            weatherForecast.User = User.Identity.Name;
            await _service.AddWeatherForecastAsync(weatherForecast);

            return RedirectToAction(nameof(Index));
        }
    }
}