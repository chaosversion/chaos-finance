namespace ChaosFinance.API.DTOs.Responses;

public class CategoryResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string? Color { get; set; }
    public decimal? Limit { get; set; }
} 