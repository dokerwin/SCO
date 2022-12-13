using AutoMapper;
using SCO.ProductService.Application.DTOs.Read.ProductDTOs;
using SCO.ProductService.Domain.Entities;

namespace SCO.ProductService.Application;
public class SCOMappingProfile : Profile
{ 
    public SCOMappingProfile()
    {
        CreateMap<ProductDto, Product>();
    }
}