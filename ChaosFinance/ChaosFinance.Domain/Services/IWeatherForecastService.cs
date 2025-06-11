using ChaosFinance.Domain.Entities;

namespace ChaosFinance.Domain.Services;

public interface IWeatherForecastService
{
    Task<WeatherForecast?> GetToday(DateTime date);
}
