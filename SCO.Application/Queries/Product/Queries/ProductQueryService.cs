using AutoMapper;
using MassTransit;
using MassTransit.Clients;
using SCO.Contracts.Requests.Product;
using SCO.Contracts.Responses;
using SCO.Contracts.DTOs;
using System.Xml.Linq;

namespace SCO.Application.Queries;

public class ProductQueryService : IProductQueryService
{
    //private readonly IRequestClient<ProductsByCategoryRequest> _requestClient;
    private readonly IBusControl _busControl;
    private readonly IMapper _mapper;

    public ProductQueryService(IBusControl busControl, IMapper mapper)
    {
        _busControl = busControl;
        _mapper = mapper;
    }
    public IEnumerable<ItemDto> GetAllProducts()
    {
        var _requestClient =
              _busControl.CreateRequestClient<ProductsByCategoryRequest>(TimeSpan.FromSeconds(10));

        var response = _requestClient.GetResponse<ProductsResponse>(new ProductsByCategoryRequest() { CategoryName = "Fruits"});

        return response.Result.Message.Items;
    }

    public IEnumerable<ItemDto> GetByCategory(string name)
    {
        var _requestClient =
            _busControl.CreateRequestClient<ProductsByCategoryRequest>(TimeSpan.FromSeconds(10));

        var response = _requestClient.GetResponse<ProductsResponse>(
                new ProductsByCategoryRequest()
                {
                    CategoryName = name
                });

        return response.Result.Message.Items;
    }

    public ItemDto GetById(Guid id)
    {
        var _requestClient =
           _busControl.CreateRequestClient<ProductsRequest>(TimeSpan.FromSeconds(10));

        var response = _requestClient.GetResponse<ProductsResponse>(
                new ProductsRequest()
                {
                    Id = id
                });

        return response.Result.Message.Items.First();
    }

    public ItemDto GetByName(string name)
    {
        ItemDto itemdtoResult = new ItemDto();
        var _requestClient =
            _busControl.CreateRequestClient<ProductsByNameRequest>(TimeSpan.FromSeconds(10));

        var response = _requestClient.GetResponse<ProductsResponse>(
                new ProductsByNameRequest()
                {
                    ProductName = name
                });

        if(response.Result.Message.Items.Count() > 0)
        {
            itemdtoResult = response.Result.Message.Items.First();
        }

        return itemdtoResult;
    }
}