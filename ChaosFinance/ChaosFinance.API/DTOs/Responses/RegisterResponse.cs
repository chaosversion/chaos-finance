using ChaosFinance.Domain.Entities;

namespace ChaosFinance.API.DTOs.Responses;

public class RegisterResponse
{
    public string Token { get; set; }
    public User User { get; set; }
}