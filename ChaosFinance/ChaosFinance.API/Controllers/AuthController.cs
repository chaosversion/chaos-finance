using System.Security.Claims;
using ChaosFinance.Application.DTOs;
using ChaosFinance.Application.DTOs.Requests;
using ChaosFinance.Application.DTOs.Responses;
using ChaosFinance.Application.Interfaces;
using ChaosFinance.Application.Services;
using ChaosFinance.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChaosFinance.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var (user, token) = await authService.Register(request.Username, request.Email, request.Password);

        return Ok(new RegisterResponse()
        {
            Token = token,
            User = user
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
            User = user
        });
    }
    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<UserDTO>> Profile()
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (id is null) return Unauthorized();
        
        var user = await authService.GetProfile(int.Parse(id));

        return Ok(user);
    }
}