using AutoMapper;
using SCO.PaymentService.Domain.Enteties;

namespace SCO.PaymentService.Application.DTOs.Mapper;
public  class SCOMappingProfile : Profile
{
    public  SCOMappingProfile()
    {
        CreateMap<Payment, PaymentDto>();
    }
}