using AutoMapper;
using ChaosFinance.Application.DTOs;
using ChaosFinance.Domain.Entities;

namespace ChaosFinance.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        CreateMap<Produto, ProdutoDTO>().ReverseMap();
        CreateMap<WeatherForecast, WeatherForecastDTO>().ReverseMap();
    }
}
