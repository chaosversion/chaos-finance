namespace ChaosFinance.API.DTOs.Responses;

public class RegisterResponse
{
    public string Token { get; set; }
    public UserResponse User { get; set; }
}

public class UserResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}