using ChaosFinance.Domain.Entities;

namespace ChaosFinance.Infrastructure.Repositories;

public interface IWeatherForecastRepository
{
    Task<WeatherForecast?> GetById(int id);
}