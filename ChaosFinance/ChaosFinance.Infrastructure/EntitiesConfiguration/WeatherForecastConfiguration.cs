using ChaosFinance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChaosFinance.Infrastructure.EntitiesConfiguration
{
    public class WeatherForecastConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Condition).IsRequired().HasConversion<string>();
            builder.Property(u => u.Description).HasMaxLength(255);
            builder.Property(u => u.Date).IsRequired();
            builder.Property(u => u.TemperatureC).IsRequired();

            // MOCKED DATA
            builder.HasData(
                new WeatherForecast
                {
                    Id = 1,
                    Condition = WeatherCondition.SUNNY,
                    TemperatureC = 25,
                    Date = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                },
                new WeatherForecast
                {
                    Id = 2,
                    Condition = WeatherCondition.CLOUDY,
                    TemperatureC = 16,
                    Date = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                },
                new WeatherForecast()
                {
                    Id = 3,
                    Condition = WeatherCondition.SNOWY,
                    TemperatureC = -5,
                    Date = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                });

        }
    }
}
