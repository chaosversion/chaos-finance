using ChaosFinance.Domain.Adapters;
using Isopoh.Cryptography.Argon2;

namespace ChaosFinance.Infrastructure.Adapters;

public class PasswordHasher(
): IPasswordHasher
{
    public string HashPassword(string password)
    {
        return Argon2.Hash(password);
    }

    public bool VerifyHashedPassword(string hashedPassword, string password)
    {
        return Argon2.Verify(hashedPassword, password);
    }
}