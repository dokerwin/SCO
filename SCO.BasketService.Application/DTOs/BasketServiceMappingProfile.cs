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
    }
}
