using ChaosFinance.Domain.Entities;

namespace ChaosFinance.Domain.Services;

public interface ICategoryService
{
    Task<Category> Create(int userId, string name, CategoryType type, string? color = null, decimal? limit = null);
    Task CreateDefaultCategories(int userId);
    Task<Category?> GetById(int id, int userId);
    Task<IEnumerable<Category>> GetByUserId(int userId);
    Task<IEnumerable<Category>> GetByUserIdAndType(int userId, CategoryType type);
    Task<Category> Update(int id, int userId, string name, CategoryType type, string? color = null, decimal? limit = null);
    Task Delete(int id, int userId);
} 