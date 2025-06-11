using ChaosFinance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace ChaosFinance.Infrastructure;

public class ApplicationDbContext: DbContext
{
    private readonly string _connectionString;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        _connectionString = "Data Source=db.sqlite";
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_connectionString)
            .EnableSensitiveDataLogging()
            .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    public DbSet<WeatherForecast> WeatherForecast { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecast>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Condition).IsRequired().HasConversion<string>();
            entity.Property(u => u.Description).HasMaxLength(255);
            entity.Property(u => u.Date).IsRequired();
            entity.Property(u => u.TemperatureC).IsRequired();

            // MOCKED DATA
            entity.HasData(
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
        });
    }
}