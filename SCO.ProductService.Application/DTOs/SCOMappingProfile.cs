using AutoMapper;
using SCO.Contracts.DTOs;
using SCO.ProductService.Application.DTOs.Read.ProductDTOs;
using SCO.ProductService.Domain.Entities;

namespace SCO.ProductService.Application;
public  class SCOMappingProfile : Profile
{
    public  SCOMappingProfile()
    {
        CreateMap<ProductDto, Product>();

        CreateMap<Product, ItemDto>()
                .ForMember(m => m.Name, c => c.MapFrom(s => s.ShortName))
                .ForMember(m => m.Price, c => c.MapFrom(s => s.Price))
                .ForMember(m => m.Description, c => c.MapFrom(s => s.Name));
    }
}