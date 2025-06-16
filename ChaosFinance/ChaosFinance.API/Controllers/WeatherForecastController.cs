using ChaosFinance.Application.Interfaces;
using ChaosFinance.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChaosFinance.API.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<WeatherForecast?> GetToday()
    {
       var today = DateTime.UtcNow;
       
       var forecast = await _weatherForecastService.GetToday(today);
       return forecast;
    }
}
