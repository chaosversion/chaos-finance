namespace ChaosFinance.Application.DTOs.Responses;

public class RegisterResponse
{
    public string Token { get; set; }
    public UserDTO User { get; set; }
}