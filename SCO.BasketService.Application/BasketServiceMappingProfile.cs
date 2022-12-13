using AutoMapper;
using SCO.Application.DTOs;
using SCO.BasketService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.BasketService.Application;

public class BasketServiceMappingProfile : Profile
{
    public BasketServiceMappingProfile()
    {
        CreateMap<Item, ItemDto>();
               
    }
   
}
