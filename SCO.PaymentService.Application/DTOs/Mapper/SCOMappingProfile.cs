using AutoMapper;
using SCO.PaymentService.Domain.Enteties;

namespace SCO.PaymentService.Application.DTOs.Mapper;
public  class SCOMappingProfile : Profile
{
    public  SCOMappingProfile()
    {
        CreateMap<Payment, PaymentDto>()
            .ForMember(s => s.MopId, c => c.MapFrom(f => f.MethodOfPayment.Id)).ReverseMap();
    }   
}