using AutoMapper;
using SCO.BasketService.Domain.Entities;
using SCO.Contracts.DTOs;

namespace SCO.BasketService.Application.DTOs;

public class BasketServiceMappingProfile : Profile
{
    /// <summary>
    /// Mapper configuration for Item
    /// </summary>
    public BasketServiceMappingProfile()
    {
        CreateMap<Item, BasketItemDetailDto>().ReverseMap();
        CreateMap<Item, ProductDto>()
        .ForMember(m => m.ShortName, c => c.MapFrom(s => s.Name))
        .ForMember(m => m.UnitPrice, c => c.MapFrom(s => s.Price))
        .ReverseMap();
    }
}
