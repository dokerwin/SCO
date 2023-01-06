using AutoMapper;
using MediatR;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.ProductService.Application.DTOs.Read.ProductDTOs;
using SCO.ProductService.Application.Queries;

namespace SCO.ProductService.Application.Handlers;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProductsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.Products.Find(s => !string.IsNullOrEmpty(s.Name));
        var listOfProducts = _mapper.Map<IEnumerable<ProductDto>>(products);

        return await Task.FromResult(listOfProducts);
    }
}