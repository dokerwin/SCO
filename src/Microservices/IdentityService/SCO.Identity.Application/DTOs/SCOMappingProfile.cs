using AutoMapper;
using SCO.Contracts.DTOs;
using SCO.Contracts.Requests.Identity;
using SCO.Identity.Domain.Entities.Employees;

namespace SCO.Indentity.Application.DTOs;

public class SCOMappingProfile : Profile
{
    public SCOMappingProfile()
    {
        CreateMap<RegisterDto, Cashier>();
        CreateMap<Cashier, CashierInfoDto>()
             .ForMember(m => m.Name, c => c.MapFrom(s => s.Firstname))
             .ForMember(m => m.Role, opt => opt.MapFrom(s => s.Role.Name)).ReverseMap();
    }
}