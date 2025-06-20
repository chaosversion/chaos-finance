using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Repositories;
using ChaosFinance.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChaosFinance.Infrastructure.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
    {
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await context.Categories
                .Include(c => c.User)
                .Include(c => c.Budgets)
                .Include(c => c.Transactions)
                .ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            if (id == null)
                return null!;

            return await context.Categories
                .Include(c => c.User)
                .Include(c => c.Budgets)
                .Include(c => c.Transactions)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Category> CreateAsync(Category item)
        {
            await context.Categories.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<Category> UpdateAsync(Category item)
        {
            context.Categories.Update(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<Category> RemoveAsync(Category item)
        {
            context.Categories.Remove(item);
            await context.SaveChangesAsync();
            return item;
        }
    }
}
