using AutoMapper;
using MediatR;
using SCO.Contracts.DTOs;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.ProductService.Application.Queries;

namespace SCO.ProductService.Application.Handlers;

public class GetProductsByIdQueryHandler : IRequestHandler<GetProductsByIdQuery, ProductDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetProductsByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDto> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.Products.GetById(request.Id);
        var productDto = _mapper.Map<ProductDto>(products);

        return await Task.FromResult(productDto);
    }
}
