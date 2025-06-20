using ChaosFinance.CrossCutting.Configuration;
using ChaosFinance.Domain.Adapters;
using ChaosFinance.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChaosFinance.Infrastructure.Auth
{
    public class JwtTokenGenerator(IOptions<JwtSettings> settings) : IJwtTokenGenerator
    {
        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Value.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            };

            var token = new JwtSecurityToken(
                issuer: settings.Value.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(settings.Value.ExpirationDays),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
