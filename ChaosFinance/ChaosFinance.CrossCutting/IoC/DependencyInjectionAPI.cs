//using ChaosFinance.Application.Interfaces;
//using ChaosFinance.Application.Mappings;
//using ChaosFinance.Application.Services;
//using ChaosFinance.Domain.Interfaces;
//using ChaosFinance.Infrastructure.Context;
//using ChaosFinance.Infrastructure.Repositories;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System;

//namespace ChaosFinance.CrossCutting.IoC;

//public static class DependencyInjectionAPI
//{
//    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
//        IConfiguration configuration)
//    {
//        services.AddDbContext<ApplicationDbContext>(options =>
//           options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

//        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
//        services.AddScoped<IProdutoRepository, ProdutoRepository>();
//        services.AddScoped<IProdutoService, ProdutoService>();
//        services.AddScoped<ICategoriaService, CategoriaService>();

//        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

//        return services;
//    }
//}
