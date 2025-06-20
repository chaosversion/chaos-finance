using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Repositories;
using ChaosFinance.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChaosFinance.Infrastructure.Repositories
{
    public class BudgetRepository(ApplicationDbContext context) : IBudgetRepository
    {
        public async Task<IEnumerable<Budget>> GetAllAsync()
        {
            return await context.Budgets
                .Include(b => b.User)
                .Include(b => b.Category)
                .ToListAsync();
        }

        public async Task<Budget> GetByIdAsync(int? id)
        {
            if (id == null) 
                return null!;
            
            return await context.Budgets
                .Include(b => b.User)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Budget> CreateAsync(Budget item)
        {
            await context.Budgets.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<Budget> UpdateAsync(Budget item)
        {
            context.Budgets.Update(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<Budget> RemoveAsync(Budget item)
        {
            context.Budgets.Remove(item);
            await context.SaveChangesAsync();
            return item;
        }
    }
}
