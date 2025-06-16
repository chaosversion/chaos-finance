using ChaosFinance.Application.DTOs;
using ChaosFinance.Domain.Entities;

namespace ChaosFinance.Application.Interfaces;

public interface IWeatherForecastService
{
    Task<WeatherForecast?> GetToday(DateTime date);
    Task<IEnumerable<WeatherForecastDTO>> GetWeatherForecasts();
    Task<WeatherForecastDTO> GetById(int? id);
    Task Add(WeatherForecastDTO produtoDto);
    Task Update(WeatherForecastDTO produtoDto);
    Task Remove(int? id);
}
