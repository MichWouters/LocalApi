using LocalClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LocalClient.Controllers
{
    public class WeatherForecastsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:44372/WeatherForecast";

            using var client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(url);
            string json = await message.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<WeatherForecast[]>(json);
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
            if (ModelState.IsValid)
            {
                var url = "https://localhost:44372/WeatherForecast";
                var json = JsonConvert.SerializeObject(weatherForecast);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:6740");
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(url, content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(weatherForecast);
        }
    }
}