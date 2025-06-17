using ChaosFinance.Domain.Entities;

namespace ChaosFinance.Domain.Repositories;

public interface IUserRepository
{
    Task Create(User user);
    Task<User?> GetByEmail(string email);
    Task<User?> GetById(int id);
    Task Update(User user);
}