using AutoMapper;
using MassTransit;
using SCO.Contracts.DTOs;
using SCO.Contracts.Requests.Product;
using SCO.Contracts.Responses;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.ProductService.Domain.Entities;
using System.Collections.Generic;

namespace SCO.ProductService.Application.MassTransit;

public class ProductsConsumer : IConsumer<ProductsRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductsConsumer(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// TODO: Refactor exception
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Consume(ConsumeContext<ProductsRequest> context)
    {
        try
        {

            var products = await _unitOfWork.Products.Find(x => x.Id == context.Message.Id);

            var orderDtos = _mapper.Map<IEnumerable<Product>, IEnumerable<ItemDto>>(products);

            await context.RespondAsync(new ProductsResponse() { Items = orderDtos });
        }
        catch (Exception ex)
        {

        }
    }
}
