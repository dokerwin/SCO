using AutoMapper;
using MassTransit;
using SCO.Contracts.DTOs;
using SCO.Contracts.Requests.Product;
using SCO.Contracts.Responses;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.ProductService.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace SCO.ProductService.Application.MassTransit;

public class ProductsByCategoryConsumer : IConsumer<ProductsByCategoryRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductsByCategoryConsumer(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// TODO: Refactor exception
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Consume(ConsumeContext<ProductsByCategoryRequest> context)
    {
        try
        {
            var categories = await _unitOfWork.Categories.Find(x => x.Name == context.Message.CategoryName);
            if (categories != null)
            {
                var products = await _unitOfWork.Products.Find(x => x.CategoryId == categories.First().Id);
                var orderDtos = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
                await context.RespondAsync(new ProductsResponse() { Products = orderDtos });
            }
            await context.RespondAsync(new ProductsResponse() { });
        }
        catch (Exception ex)
        {
            
        }   
    }
}
