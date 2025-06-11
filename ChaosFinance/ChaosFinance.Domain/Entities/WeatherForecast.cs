using System.ComponentModel.DataAnnotations.Schema;

namespace ChaosFinance.Domain.Entities;

[Table("Weather")]
public class WeatherForecast
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    public WeatherCondition Condition { get; init; }
    public DateTime Date { get; init; } = DateTime.UtcNow;
    public decimal TemperatureC { get; init; }
    public string Description { get; init; } = string.Empty;
}

public enum WeatherCondition {
    SUNNY,
    CLOUDY,
    RAINY,
    STORMY,
    SNOWY
}