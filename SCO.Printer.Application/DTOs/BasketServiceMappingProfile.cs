using AutoMapper;
using SCO.Contracts.DTOs;
using SCO.PrinterService.Application.DTOs;
using SCO.PrinterService.Domain.Entities;

namespace SCO.BasketService.Application.DTOs;

public class PrinterServiceMappingProfile : Profile
{
    /// <summary>
    /// Mapper configuration for Item
    /// </summary>
    public PrinterServiceMappingProfile()
    {

        CreateMap<RawTicket, TicketDto>()
            .ForMember(s => s.OrderedOn, c => c.MapFrom(f => f.TicketTime))
            .ForMember(s => s.OrderId, c => c.MapFrom(f => f.TicketId))
            .ReverseMap();

        CreateMap<RawItem, BasketItemDetailDto>()
            .ForMember(s => s.Quantity, c => c.MapFrom(f => f.Quantity))
            .ForMember(s => s.UnitPrice, c => c.MapFrom(f => f.UnitPrice))
            .ForMember(s => s.ShortName, c => c.MapFrom(f => f.ItemName))
            .ReverseMap();


    }
}
