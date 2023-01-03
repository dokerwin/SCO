using AutoMapper;
using SCO.Application.DTOs;
using SCO.Domain.Entities.Employees;

public class SCOMappingProfile : Profile
    {
        public SCOMappingProfile()
        {
            CreateMap<RegisterUserDto, Cashier>();
        }
    }