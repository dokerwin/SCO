using AutoMapper;
using MassTransit;
using SCO.Contracts.DTOs;
using SCO.Contracts.Requests.Product;
using SCO.Contracts.Responses;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.ProductService.Domain.Entities;
using System.Collections.Generic;

namespace SCO.ProductService.Application.MassTransit;

public class ProductsByNameConsumer : IConsumer<ProductsByNameRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductsByNameConsumer(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// TODO: Refactor exception
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Consume(ConsumeContext<ProductsByNameRequest> context)
    {
        try
        {
            
            var products = await _unitOfWork.Products.Find(x => x.Name == context.Message.ProductName);

            var productDtos = _mapper.Map<IEnumerable<ItemDto>>(products);

            await context.RespondAsync(new ProductsResponse() { Items = productDtos });
        }
        catch (Exception ex)
        {

        }
    }
}
