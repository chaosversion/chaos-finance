using ChaosFinance.Application.DTOs;

namespace ChaosFinance.Application.Interfaces;

public interface IAuthService
{
    Task<(UserDTO user, string token)> Register(string username, string email, string password);
    Task<(UserDTO user, string token)> Login(string email, string password);
    Task<UserDTO?> GetProfile(int userId);
}