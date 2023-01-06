using AutoMapper;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.ProductService.Application.DTOs.Read.ProductDTOs;
using SCO.ProductService.Domain.Entities;
using System.Xml.Linq;

namespace SCO.ProductService.Application.Queries;

public class ProductQueryService : IProductQueryService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ProductQueryService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    } 
  
    public async Task<ProductDto> GetById(Guid id)
    {
        var product = await _unitOfWork.Products.GetById(id);

        if(product is not null)
        {
           return _mapper.Map<ProductDto>(product);
        }
        else
        {
            return new ProductDto();
        }
    }

    public async Task<IEnumerable<ProductDto>> GetByNameAsync(string name)
    {
        var products = await _unitOfWork.Products.Find(s => s.Name == name);
        var listOfProducts = new List<ProductDto>();

        foreach (var prod in products)
        {
            listOfProducts.Add(_mapper.Map<ProductDto>(prod));
        }

        return listOfProducts;
    }

    public async Task<IEnumerable<ProductDto>> GetByCategory(string name)
    {
        var products = await _unitOfWork.Products.Find(s => s.Name == name);
        var listOfProducts = new List<ProductDto>();

        foreach (var prod in products)
        {
            listOfProducts.Add(_mapper.Map<ProductDto>(prod));
        }

        return listOfProducts;
    }

    public async Task<ProductDto> GetByName(string name)
    {
        var products = await _unitOfWork.Products.Find(s => s.Name == name);
        var listOfProducts = new List<ProductDto>();

        foreach (var prod in products)
        {
            listOfProducts.Add(_mapper.Map<ProductDto>(prod));
        }

        return listOfProducts.First();
    }

    public async Task<IEnumerable<ProductDto>> GetAllProducts()
    {
        var products = await _unitOfWork.Products.Find(s => !string.IsNullOrEmpty(s.Name));
        var listOfProducts = new List<ProductDto>();

        foreach (var prod in products)
        {
            listOfProducts.Add(_mapper.Map<ProductDto>(prod));
        }

        return listOfProducts;
    }
}