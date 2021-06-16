using System;
using LocalClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Threading.Tasks;
using LocalClient.Services;
using Microsoft.Extensions.Logging;

namespace LocalClient.Controllers
{
    [Authorize]
    public class WeatherForecastsController : Controller
    {
        private readonly IWeatherForecastService _service;
        private readonly ILogger _logger;
        public WeatherForecastsController(IWeatherForecastService service, ILogger<WeatherForecastsController> logger)
        {
            _service = service;
            _logger = logger;
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

            _logger.LogInformation($@"{DateTime.Now}: User {User.Identity.Name} has added a new forecast");
            return RedirectToAction(nameof(Index));
        }
    }
}