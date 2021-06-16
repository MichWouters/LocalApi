using System.Threading.Tasks;
using LocalClient.Models;

namespace LocalClient.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecasts();
        Task AddWeatherForecastAsync(WeatherForecast weatherForecast);
    }
}