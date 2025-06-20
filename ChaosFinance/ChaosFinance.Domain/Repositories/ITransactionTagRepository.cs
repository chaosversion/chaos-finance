using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Interfaces;

namespace ChaosFinance.Domain.Repositories
{
    public interface ITransactionTagRepository : IBaseRepository<TransactionTag>
    {
        Task<IEnumerable<TransactionTag>> GetByTransactionIdAsync(int transactionId);
        Task<IEnumerable<TransactionTag>> GetByTagIdAsync(int tagId);
    }
}
