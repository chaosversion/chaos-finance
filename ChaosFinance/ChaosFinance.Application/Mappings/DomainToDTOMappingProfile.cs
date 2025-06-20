using AutoMapper;
using ChaosFinance.Application.DTOs;
using ChaosFinance.Domain.Entities;

namespace Catalogo.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Account, AccountDTO>().ReverseMap();
        CreateMap<Budget, BudgetDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Tag, TagDTO>().ReverseMap();
        CreateMap<Transaction, TransactionDTO>().ReverseMap();
        CreateMap<TransactionTag, TransactionTagDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
    }
}
