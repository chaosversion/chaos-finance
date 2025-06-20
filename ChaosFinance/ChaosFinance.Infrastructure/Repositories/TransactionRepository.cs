using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Repositories;
using ChaosFinance.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChaosFinance.Infrastructure.Repositories
{
    public class TransactionRepository(ApplicationDbContext context) : ITransactionRepository
    {
        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await context.Transactions
                .Include(t => t.Account)
                .Include(t => t.DestinationAccount)
                .Include(t => t.Category)
                .Include(t => t.User)
                .Include(t => t.TransactionTags)
                    .ThenInclude(tt => tt.Tag)
                .ToListAsync();
        }

        public async Task<Transaction> GetByIdAsync(int? id)
        {
            if (id == null)
                return null!;

            return await context.Transactions
                .Include(t => t.Account)
                .Include(t => t.DestinationAccount)
                .Include(t => t.Category)
                .Include(t => t.User)
                .Include(t => t.TransactionTags)
                    .ThenInclude(tt => tt.Tag)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Transaction> CreateAsync(Transaction transaction)
        {
            await context.Transactions.AddAsync(transaction);
            await context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> UpdateAsync(Transaction transaction)
        {
            context.Transactions.Update(transaction);
            await context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> RemoveAsync(Transaction transaction)
        {
            context.Transactions.Remove(transaction);
            await context.SaveChangesAsync();
            return transaction;
        }
    }
}
