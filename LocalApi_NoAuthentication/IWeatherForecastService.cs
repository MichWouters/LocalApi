using System.Threading.Tasks;
using LocalApi_NoAuthentication;

namespace LocalClient.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecasts();
        Task AddWeatherForecastAsync(WeatherForecast weatherForecast);
    }
}