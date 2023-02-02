using AutoMapper;
using MediatR;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.Contracts.DTOs;
using SCO.ProductService.Application.Queries;
using System.Xml.Linq;

namespace SCO.ProductService.Application.Handlers;

public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryQuery, IEnumerable<ProductDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetProductsByCategoryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.Categories.Find(s => s.Name == request.CategoryDto.Name);
        var listOfProducts = _mapper.Map<IEnumerable<ProductDto>>(products);

        return await Task.FromResult(listOfProducts);
    }
}

