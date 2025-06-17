using ChaosFinance.Domain.Entities;

namespace ChaosFinance.Domain.Repositories;

public interface ICategoryRepository
{
    Task Create(Category category);
    Task CreateRange(IEnumerable<Category> categories);
    Task<Category?> GetById(int id);
    Task<IEnumerable<Category>> GetByUserId(int userId);
    Task<IEnumerable<Category>> GetByUserIdAndType(int userId, CategoryType type);
    Task Update(Category category);
    Task Delete(Category category);
} 