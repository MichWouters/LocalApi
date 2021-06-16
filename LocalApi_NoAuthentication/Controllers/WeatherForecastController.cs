using LocalApi_NoAuthentication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocalApi_NoAuthentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ApiContext _ctx;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ApiContext ctx, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _ctx.Forecasts.Any() 
                ? _ctx.Forecasts.ToArray() 
                : GetDummyData();
        }

        public IEnumerable<WeatherForecast> GetDummyData()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public void Add(WeatherForecast forecast)
        {
            _ctx.Forecasts.Add(forecast);
            _ctx.SaveChanges();
        }
    }
}
