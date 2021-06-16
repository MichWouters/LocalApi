using LocalClient.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LocalClient.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public async Task<WeatherForecast[]> GetForecasts()
        {
            var url = "https://localhost:44372/WeatherForecast";

            using var client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(url);
            string json = await message.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<WeatherForecast[]>(json);

            return result;
        }

        public async Task AddWeatherForecastAsync(WeatherForecast weatherForecast)
        {
            var url = "https://localhost:44372/WeatherForecast";
            var json = JsonConvert.SerializeObject(weatherForecast);

            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:6740")
            };
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);
            string resultContent = await result.Content.ReadAsStringAsync();
            Console.WriteLine(resultContent);
        }
    }
}
