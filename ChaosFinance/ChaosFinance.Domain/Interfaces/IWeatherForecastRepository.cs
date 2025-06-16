using ChaosFinance.Domain.Entities;

namespace ChaosFinance.Domain.Interfaces;

public interface IWeatherForecastRepository
{
    Task<WeatherForecast?> GetToday(DateTime date);
    Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync();
    Task<WeatherForecast> GetByIdAsync(int? id);
    Task<WeatherForecast> CreateAsync(WeatherForecast weatherForecast);
    Task<WeatherForecast> UpdateAsync(WeatherForecast weatherForecast);
    Task<WeatherForecast> RemoveAsync(WeatherForecast weatherForecast);
}