using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Interfaces;
using ChaosFinance.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChaosFinance.Infrastructure.Repositories;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    private ApplicationDbContext _weatherForecastContext;
    public WeatherForecastRepository(ApplicationDbContext context)
    {
        _weatherForecastContext = context;
    }
    public async Task<WeatherForecast?> GetToday(DateTime date)
    {
        int id = Random.Shared.Next(1, 4); // Assuming we have 3 mocked weather forecasts
        var forecast = await _weatherForecastContext.WeatherForecast.FindAsync(id);

        return forecast;
    }
    public async Task<WeatherForecast> CreateAsync(WeatherForecast weatherForecast)
    {
        _weatherForecastContext.Add(weatherForecast);
        await _weatherForecastContext.SaveChangesAsync();
        return weatherForecast;
    }

    public async Task<WeatherForecast> GetByIdAsync(int? id)
    {
        return await _weatherForecastContext.WeatherForecast.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
    {
        return await _weatherForecastContext.WeatherForecast.ToListAsync();
    }

    public async Task<WeatherForecast> RemoveAsync(WeatherForecast weatherForecast)
    {
        _weatherForecastContext.Remove(weatherForecast);
        await _weatherForecastContext.SaveChangesAsync();
        return weatherForecast;
    }

    public async Task<WeatherForecast> UpdateAsync(WeatherForecast weatherForecast)
    {
        _weatherForecastContext.Update(weatherForecast);
        await _weatherForecastContext.SaveChangesAsync();
        return weatherForecast;
    }
}
