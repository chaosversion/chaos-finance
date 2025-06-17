using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChaosFinance.Infrastructure.Repositories;

public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    public async Task Create(Category category)
    {
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
    }

    public async Task CreateRange(IEnumerable<Category> categories)
    {
        await context.Categories.AddRangeAsync(categories);
        await context.SaveChangesAsync();
    }

    public async Task<Category?> GetById(int id)
    {
        return await context.Categories
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Category>> GetByUserId(int userId)
    {
        return await context.Categories
            .Where(c => c.UserId == userId)
            .OrderBy(c => c.Type)
            .ThenBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetByUserIdAndType(int userId, CategoryType type)
    {
        return await context.Categories
            .Where(c => c.UserId == userId && c.Type == type)
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task Update(Category category)
    {
        context.Categories.Update(category);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Category category)
    {
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
    }
} 