using System.Security.Claims;
using ChaosFinance.API.DTOs.Requests;
using ChaosFinance.API.DTOs.Responses;
using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChaosFinance.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(
    IAuthService authService
): ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var (user, token) = await authService.Register(request.Username, request.Email, request.Password);

        return Ok(new RegisterResponse()
        {
            Token = token,
            User = new UserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            }
        });
    }
    
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var (user, token) = await authService.Login(request.Email, request.Password);

        return Ok(new LoginResponse
        {
            Token = token,
            User = new UserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            }
        });
    }
    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<User>> Profile()
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (id is null) return Unauthorized();
        
        var user = await authService.GetProfile(int.Parse(id));
        
        return Ok(user);
    }
}