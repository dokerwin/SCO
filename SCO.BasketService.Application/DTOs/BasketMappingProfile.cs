using AutoMapper;
using SCO.BasketService.Domain.Entities;
using SCO.Contracts.DTOs;

namespace SCO.BasketService.Application.DTOs;
public class BasketMappingProfile : Profile
{
    public BasketMappingProfile()
    {
        CreateMap<Item, ItemDto>();
    }
}