using AutoMapper;
using ChaosFinance.Application.DTOs;
using ChaosFinance.Application.Interfaces;
using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Interfaces;

namespace ChaosFinance.Application.Services;

public class WeatherForecastService: IWeatherForecastService
{
    private IWeatherForecastRepository _weatherForecastRepository;

    private readonly IMapper _mapper;
    public WeatherForecastService(IMapper mapper, IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository ??
             throw new ArgumentNullException(nameof(weatherForecastRepository));

        _mapper = mapper;
    }

    public async Task<WeatherForecast?> GetToday(DateTime date)
    {
        var forecast = await _weatherForecastRepository.GetByIdAsync(
            new Random().Next(1, 4) // Assuming we have 3 mocked weather forecasts
        );

        return forecast;
    }
    public async Task<IEnumerable<WeatherForecastDTO>> GetWeatherForecasts()
    {
        var weatherForecastEntity = await _weatherForecastRepository.GetWeatherForecastsAsync();
        return _mapper.Map<IEnumerable<WeatherForecastDTO>>(weatherForecastEntity);
    }

    public async Task<WeatherForecastDTO> GetById(int? id)
    {
        var weatherForecastEntity = await _weatherForecastRepository.GetByIdAsync(id);
        return _mapper.Map<WeatherForecastDTO>(weatherForecastEntity);
    }

    public async Task Add(WeatherForecastDTO weatherForecastDTO)
    {
        var weatherForecastEntity = _mapper.Map<WeatherForecast>(weatherForecastDTO);
        await _weatherForecastRepository.CreateAsync(weatherForecastEntity);
    }

    public async Task Update(WeatherForecastDTO weatherForecastDTO)
    {

        var weatherForecastEntity = _mapper.Map<WeatherForecast>(weatherForecastDTO);
        await _weatherForecastRepository.UpdateAsync(weatherForecastEntity);
    }

    public async Task Remove(int? id)
    {
        var weatherForecastEntity = _weatherForecastRepository.GetByIdAsync(id).Result;
        await _weatherForecastRepository.RemoveAsync(weatherForecastEntity);
    }
}
