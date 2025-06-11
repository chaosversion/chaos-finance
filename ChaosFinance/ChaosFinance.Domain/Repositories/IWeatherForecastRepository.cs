using ChaosFinance.Domain.Entities;

namespace ChaosFinance.Domain.Repositories;

public interface IWeatherForecastRepository
{
    Task<WeatherForecast?> GetById(int id);
}