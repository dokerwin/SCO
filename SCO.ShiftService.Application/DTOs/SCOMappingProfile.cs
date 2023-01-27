using AutoMapper;
using SCO.Contracts.DTOs;
using SCO.ShiftService.Domain.Entities;

namespace SCO.ShiftService.Application.DTOs;

public class SCOMappingProfile : Profile
{
    public SCOMappingProfile()
    {
        CreateMap<Shift, ShiftInfoDto>()
             .ForMember(m => m.CashierId, opt => opt.MapFrom(s => s.CashierId)).ReverseMap();
    }
}