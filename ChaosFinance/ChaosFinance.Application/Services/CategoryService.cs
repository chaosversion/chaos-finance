using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Repositories;
using ChaosFinance.Domain.Services;

namespace ChaosFinance.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    private static readonly List<(string Name, CategoryType Type, string? Color)> DefaultCategories = new()
    {
        // Income Categories
        ("Salary", CategoryType.Income, "#4CAF50"),
        ("Gifts", CategoryType.Income, "#9C27B0"),
        ("Other Income", CategoryType.Income, "#00BCD4"),

        // Expense Categories
        ("Housing", CategoryType.Expense, "#FF5722"),
        ("Transportation", CategoryType.Expense, "#3F51B5"),
        ("Food", CategoryType.Expense, "#FF9800"),
        ("Utilities", CategoryType.Expense, "#795548"),
        ("Healthcare", CategoryType.Expense, "#F44336"),
        ("Personal Spending", CategoryType.Expense, "#E91E63"),
        ("Entertainment", CategoryType.Expense, "#673AB7"),
        ("Savings & Investments", CategoryType.Expense, "#009688"),
        ("Debt Payments", CategoryType.Expense, "#607D8B"),
        ("Donations", CategoryType.Expense, "#8BC34A")
    };

    public async Task<Category> Create(int userId, string name, CategoryType type, string? color = null, decimal? limit = null)
    {
        var category = new Category
        {
            UserId = userId,
            Name = name,
            Type = type,
            Color = color,
            Limit = limit
        };

        await categoryRepository.Create(category);
        return category;
    }

    public async Task CreateDefaultCategories(int userId)
    {
        var categories = DefaultCategories.Select(dc => new Category
        {
            UserId = userId,
            Name = dc.Name,
            Type = dc.Type,
            Color = dc.Color
        });

        await categoryRepository.CreateRange(categories);
    }

    public async Task<Category?> GetById(int id, int userId)
    {
        var category = await categoryRepository.GetById(id);
        
        // Ensure the category belongs to the user
        if (category?.UserId != userId)
        {
            return null;
        }

        return category;
    }

    public async Task<IEnumerable<Category>> GetByUserId(int userId)
    {
        return await categoryRepository.GetByUserId(userId);
    }

    public async Task<IEnumerable<Category>> GetByUserIdAndType(int userId, CategoryType type)
    {
        return await categoryRepository.GetByUserIdAndType(userId, type);
    }

    public async Task<Category> Update(int id, int userId, string name, CategoryType type, string? color = null, decimal? limit = null)
    {
        var category = await GetById(id, userId);
        
        if (category == null)
        {
            throw new InvalidOperationException("Category not found or access denied.");
        }

        category.Name = name;
        category.Type = type;
        category.Color = color;
        category.Limit = limit;

        await categoryRepository.Update(category);
        return category;
    }

    public async Task Delete(int id, int userId)
    {
        var category = await GetById(id, userId);
        
        if (category == null)
        {
            throw new InvalidOperationException("Category not found or access denied.");
        }

        await categoryRepository.Delete(category);
    }
} 