using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChaosFinance.Infrastructure.Repositories;

public class WeatherForecastRepository(ApplicationDbContext context): IWeatherForecastRepository
{
    public async Task<WeatherForecast> Create(WeatherForecast weatherForecast)
    {
        await context.WeatherForecast.AddAsync(weatherForecast);
        await context.SaveChangesAsync();
        return weatherForecast;
    }

    public async Task<WeatherForecast?> GetById(int id)
    {
        return await context.WeatherForecast
            .AsNoTracking()
            .FirstOrDefaultAsync(wf => wf.Id == id);
    }
}