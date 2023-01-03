using AutoMapper;
using SCO.Identity.Domain.Entities.Employees;

namespace SCO.Indentity.Application.DTOs;

public class SCOMappingProfile : Profile
    {
        public SCOMappingProfile()
        {
            CreateMap<RegisterCashierDto, Cashier>();
        }
    }