using System.ComponentModel.DataAnnotations.Schema;

namespace ChaosFinance.Domain.Entities;

public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public string Name { get; set; }
    
    public string? Color { get; set; }
    
    public decimal? Limit { get; set; }
    
    public CategoryType Type { get; set; }
    
    // Navigation property
    public User User { get; set; }
}

public enum CategoryType
{
    Expense,
    Income
} 