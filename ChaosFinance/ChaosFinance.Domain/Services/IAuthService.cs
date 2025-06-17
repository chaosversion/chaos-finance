using ChaosFinance.Domain.Entities;

namespace ChaosFinance.Domain.Services;

public interface IAuthService
{
    Task<(User user, string token)> Register(string username, string email, string password);
    Task<(User user, string token)> Login(string email, string password);
    Task<User?> GetProfile(int userId);
}