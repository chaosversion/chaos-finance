namespace ChaosFinance.Application.DTOs.Responses;

public class LoginResponse
{
    public string Token { get; set; }
    public UserDTO User { get; set; }
}