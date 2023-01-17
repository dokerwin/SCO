using AutoMapper;
using SCO.Contracts.DTOs;
using SCO.ProductService.Domain.Entities;

namespace SCO.ProductService.Application;
public  class SCOMappingProfile : Profile
{
    public  SCOMappingProfile()
    {
        CreateMap<Product, ProductDto>()
                .ForMember(m => m.ShortName, c => c.MapFrom(s => s.ShortName))
                .ForMember(m => m.UnitPrice, c => c.MapFrom(s => s.Price))
                .ForMember(m => m.Barcode, c => c.MapFrom(s => s.Barcode))
                .ReverseMap();

    }
}