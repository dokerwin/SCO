using AutoMapper;
using MediatR;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.Contracts.DTOs;
using SCO.ProductService.Application.Queries;

namespace SCO.ProductService.Application.Handlers;

public class GetProductsByNameHandlers : IRequestHandler<GetProductsByNameQuery, IEnumerable<ProductDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetProductsByNameHandlers(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.Products.Find(s => s.ShortName == request.ProductDto.ShortName);
        var listOfProducts = _mapper.Map<IEnumerable<ProductDto>>(products);

        return await Task.FromResult(listOfProducts);
    }
}

