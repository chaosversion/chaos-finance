using ChaosFinance.Domain.Entities;

namespace ChaosFinance.Domain.Adapters
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
