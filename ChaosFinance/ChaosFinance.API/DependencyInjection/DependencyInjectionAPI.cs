using Catalogo.Application.Mappings;
using ChaosFinance.Application.DTOs.Responses;
using ChaosFinance.Application.Interfaces;
using ChaosFinance.Application.Services;
using ChaosFinance.CrossCutting.Configuration;
using ChaosFinance.Domain.Adapters;
using ChaosFinance.Domain.Repositories;
using ChaosFinance.Infrastructure.Adapters;
using ChaosFinance.Infrastructure.Auth;
using ChaosFinance.Infrastructure.Context;
using ChaosFinance.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ChaosFinance.API.DependencyInjection;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
           options.UseLazyLoadingProxies()
           .UseSqlite(configuration.GetConnectionString("DefaultConnection"))
           );

        // Services
        services.AddScoped<IAuthService, AuthService>();

        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();

        // Adapters
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opts =>
            {
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]))
                };

                opts.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        // Suppress the default response
                        context.HandleResponse();

                        // Write custom 401 response
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";
                        var response = new ErrorResponse
                        {
                            StatusCode = StatusCodes.Status401Unauthorized,
                            Message = "You must be authenticated to access this resource.",
                        };

                        await context.Response.WriteAsJsonAsync(response);
                    }
                };
            });

        return services;
    }
}
