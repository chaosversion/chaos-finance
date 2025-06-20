using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Interfaces;

namespace ChaosFinance.Domain.Repositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<Account> GetByNameAndUserIdAsync(string name, int userId);
    }
}
