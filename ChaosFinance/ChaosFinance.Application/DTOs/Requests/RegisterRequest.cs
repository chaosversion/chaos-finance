using ChaosFinance.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ChaosFinance.Application.DTOs.Requests;

public class RegisterRequest
{
    [Required(ErrorMessage = "Name is required.")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Person type is required.")]
    [EnumDataType(typeof(PersonType), ErrorMessage = "Invalid person type.")]
    public PersonType Type { get; set; }
    
    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
    [MaxLength(20, ErrorMessage = "Password must be at most 20 characters.")]
    public string Password { get; set; }
}