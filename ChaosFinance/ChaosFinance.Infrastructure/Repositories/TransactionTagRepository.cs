using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Repositories;
using ChaosFinance.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChaosFinance.Infrastructure.Repositories
{
    public class TransactionTagRepository(ApplicationDbContext context) : ITransactionTagRepository
    {
        public async Task<IEnumerable<TransactionTag>> GetAllAsync()
        {
            return await context.TransactionTags
                .Include(tt => tt.Transaction)
                .Include(tt => tt.Tag)
                .ToListAsync();
        }

        public async Task<TransactionTag> GetByIdAsync(int? id)
        {
            //deve ser ajustado pois é chave composta F
            return null!;
        }

        public async Task<TransactionTag> CreateAsync(TransactionTag item)
        {
            await context.TransactionTags.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<TransactionTag> UpdateAsync(TransactionTag item)
        {
            context.TransactionTags.Update(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<TransactionTag> RemoveAsync(TransactionTag item)
        {
            context.TransactionTags.Remove(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<TransactionTag>> GetByTransactionIdAsync(int transactionId)
        {
            return await context.TransactionTags
                .Include(tt => tt.Tag)
                .Where(tt => tt.TransactionId == transactionId)
                .ToListAsync();
        }

        public async Task<IEnumerable<TransactionTag>> GetByTagIdAsync(int tagId)
        {
            return await context.TransactionTags
                .Include(tt => tt.Transaction)
                .Where(tt => tt.TagId == tagId)
                .ToListAsync();
        }
    }
}
