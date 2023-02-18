using AutoMapper;

namespace SCO.PromotionService.Application;
public  class SCOMappingProfile : Profile
{
    public  SCOMappingProfile()
    {
        CreateMap<Ite, ProductDto>()
                .ForMember(m => m.ShortName, c => c.MapFrom(s => s.ShortName))
                .ForMember(m => m.UnitPrice, c => c.MapFrom(s => s.Price))
                .ForMember(m => m.Barcode, c => c.MapFrom(s => s.Barcode))
                .ForMember(m => m.CategoryId, c => c.MapFrom(s => s.CategoryId))
                .ReverseMap();

    }
}