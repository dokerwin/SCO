using AutoMapper;
using SCO.BasketService.Domain.Entities;
using SCO.Contracts.DTOs;
using SCO.Contracts.Responses;

namespace SCO.BasketService.Application;

public class BasketServiceMappingProfile : Profile
{
    /// <summary>
    /// Mapper configuration for Item
    /// </summary>
    public BasketServiceMappingProfile()
    {
        CreateMap<Item, ItemDto>().ReverseMap();
    } 
}
