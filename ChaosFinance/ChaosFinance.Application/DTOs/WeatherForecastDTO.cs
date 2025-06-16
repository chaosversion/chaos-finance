using System.ComponentModel.DataAnnotations;

namespace ChaosFinance.Application.DTOs;

public class WeatherForecastDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "A Condition é obrigatória")]
    public WeatherCondition Condition { get; set; }

    [Required(ErrorMessage = "A Date é obrigatória")]
    public DateTime Date { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "A TemperatureC é obrigatória")]
    public decimal TemperatureC { get; set; }

    [Required(ErrorMessage = "A Description é obrigatória")]
    [MinLength(5)]
    [MaxLength(250)]
    public string Description { get; set; } = string.Empty;
}

public enum WeatherCondition
{
    SUNNY,
    CLOUDY,
    RAINY,
    STORMY,
    SNOWY
}
