using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Repositories;
using ChaosFinance.Domain.Services;

namespace ChaosFinance.Application;

public class WeatherForecastService: IWeatherForecastService
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;

    public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }

    public async Task<WeatherForecast?> GetToday(DateTime date)
    {
        var forecast = await _weatherForecastRepository.GetById(
            new Random().Next(1, 4) // Assuming we have 3 mocked weather forecasts
        );

        return forecast;
    }
}