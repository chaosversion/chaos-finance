using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Repositories;
using ChaosFinance.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChaosFinance.Infrastructure.Repositories
{
    public class AccountRepository(ApplicationDbContext context) : IAccountRepository
    {
        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await context.Accounts
                .Include(a => a.User)
                .Include(a => a.TransactionsAsOrigin)
                .Include(a => a.TransactionsAsDestination)
                .ToListAsync();
        }

        public async Task<Account> GetByIdAsync(int? id)
        {
            if (id == null)
                return null!;

            return await context.Accounts
                .Include(a => a.User)
                .Include(a => a.TransactionsAsOrigin)
                .Include(a => a.TransactionsAsDestination)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Account> CreateAsync(Account obj)
        {
            await context.Accounts.AddAsync(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<Account> UpdateAsync(Account obj)
        {
            context.Accounts.Update(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<Account> RemoveAsync(Account obj)
        {
            context.Accounts.Remove(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<Account> GetByNameAndUserIdAsync(string name, int userId)
        {
            return await context.Accounts.FirstOrDefaultAsync(a => a.Name == name && a.UserId == userId);
        }
    }
}
