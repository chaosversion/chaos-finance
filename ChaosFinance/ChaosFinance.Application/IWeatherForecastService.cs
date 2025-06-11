using ChaosFinance.Domain.Entities;

namespace ChaosFinance.Application;

public interface IWeatherForecastService
{
    Task<WeatherForecast?> GetToday(DateTime date);
}
