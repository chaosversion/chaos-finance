using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChaosFinance.Domain.Adapters;
using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Repositories;
using ChaosFinance.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ChaosFinance.Application.Services;

public class AuthService(
    IConfiguration configuration,
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    ICategoryService categoryService
) : IAuthService
{
    public async Task<(User user, string token)> Register(string username, string email, string password)
    {
        var existingUser = await userRepository.GetByEmail(email);

        if (existingUser  is not null)
        {
            throw new InvalidOperationException("User with this email already exists.");
        }
        
        var user = new User
        {
            Username = username,
            Email = email,
            Password = passwordHasher.HashPassword(password)
        };

        await userRepository.Create(user);

        // Create default categories for the new user
        await categoryService.CreateDefaultCategories(user.Id);

        var token = GenerateJwtToken(user);

        return (user, token);
    }


    public async Task<(User user, string token)> Login(string email, string password)
    {
        // Retrieve user by email
        var user = await userRepository.GetByEmail(email);

        // If user is not found, return null or throw an exception
        if (user == null)
        {
            throw new InvalidOperationException("Invalid email or password.");
        }

        // Verify the password
        var result = passwordHasher.VerifyHashedPassword(user.Password, password);

        // If the password does not match, throw an exception
        if (result is false)
        {
            throw new InvalidOperationException("Invalid email or password.");
        }

        // Generate JWT Token
        var token = GenerateJwtToken(user);

        // Return the user and token
        return (user, token);
    }
    
    private string GenerateJwtToken(User user)
    {
        var secretKey = configuration["Jwt:SecretKey"];
        var issuer = configuration["Jwt:Issuer"];

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    public async Task<User?> GetProfile(int userId)
    {
        return await userRepository.GetById(userId);
    }
}