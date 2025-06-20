using AutoMapper;
using ChaosFinance.Application.DTOs;
using ChaosFinance.Application.Interfaces;
using ChaosFinance.Domain.Adapters;
using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Repositories;

namespace ChaosFinance.Application.Services;

public class AuthService(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtTokenGenerator jwtTokenGenerator,
    IMapper mapper
) : IAuthService
{
    public async Task<(UserDTO user, string token)> Register(string username, string email, string password)
    {
        var existingUser = await userRepository.GetByEmail(email);

        if (existingUser  is not null)
        {
            throw new InvalidOperationException("User with this email already exists.");
        }

        var userDTO = new UserDTO
        {
            Username = username, Email = email, Name = username, PasswordHash = passwordHasher.HashPassword(password), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        };

        User user = mapper.Map<User>(userDTO);

        await userRepository.Create(user);

        var token = jwtTokenGenerator.GenerateToken(user);

        userDTO = mapper.Map<UserDTO>(userDTO);

        return (userDTO, token);
    }

    public async Task<(UserDTO user, string token)> Login(string email, string password)
    {
        var user = await userRepository.GetByEmail(email);

        if (user == null || !passwordHasher.VerifyHashedPassword(user.PasswordHash, password))
        {
            throw new InvalidOperationException("Invalid email or password.");
        }

        var token = jwtTokenGenerator.GenerateToken(user);

        var userDTO = mapper.Map<UserDTO>(user);

        return (userDTO, token);
    }
    public async Task<UserDTO?> GetProfile(int userId)
    {
        var user = await userRepository.GetById(userId);

        return mapper.Map<UserDTO>(user);
    }
}
