using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Repositories;
using ChaosFinance.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChaosFinance.Infrastructure.Repositories
{
    public class TagRepository(ApplicationDbContext context) : ITagRepository
    {
        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await context.Tags
                .Include(t => t.User)
                .Include(t => t.TransactionTags)
                .ToListAsync();
        }

        public async Task<Tag> GetByIdAsync(int? id)
        {
            if (id == null)
                return null!;

            return await context.Tags
                .Include(t => t.User)
                .Include(t => t.TransactionTags)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tag> CreateAsync(Tag item)
        {
            await context.Tags.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<Tag> UpdateAsync(Tag item)
        {
            context.Tags.Update(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<Tag> RemoveAsync(Tag item)
        {
            context.Tags.Remove(item);
            await context.SaveChangesAsync();
            return item;
        }
    }
}
