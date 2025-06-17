namespace ChaosFinance.API.DTOs.Requests;

public class UpdateCategoryRequest
{
    public required string Name { get; set; }
    public required string Type { get; set; } // "Expense" or "Income"
    public string? Color { get; set; }
    public decimal? Limit { get; set; }
} 