using AutoMapper;
using SCO.Contracts.Requests.Identity;
using SCO.Identity.Domain.Entities.Employees;

namespace SCO.Indentity.Application.DTOs;

public class SCOMappingProfile : Profile
    {
        public SCOMappingProfile()
        {
            CreateMap<RegisterRequest, Cashier>();
        }
    }