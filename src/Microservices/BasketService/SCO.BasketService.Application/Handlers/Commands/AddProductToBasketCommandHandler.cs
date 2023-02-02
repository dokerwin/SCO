using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SCO.BasketService.Application.Commands;
using SCO.BasketService.Domain;
using SCO.BasketService.Domain.Entities;
using SCO.Contracts.Requests.Product;
using SCO.Contracts.Responses;
using SCO.Contracts.Responses.Basket;

namespace SCO.BasketService.Application.Handlers.Commands;

public class AddProductToBasketCommandHandler : IRequestHandler<AddProductToBasketCommand, AddProductToBasketResposne>
{
    private readonly IBusControl _busControl;
    private readonly IMapper _mapper;
    private readonly IBasketLogic _basketLogic;
    private readonly ILogger<AddProductToBasketCommandHandler> _logger;

    public AddProductToBasketCommandHandler(IBusControl busControl,
        IMapper mapper,
        IBasketLogic basketLogic,
        ILogger<AddProductToBasketCommandHandler> logger)
    {
        _busControl = busControl;
        _mapper = mapper;
        _basketLogic = basketLogic;
        _logger = logger;
    }


    public async Task<AddProductToBasketResposne> Handle(AddProductToBasketCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (_basketLogic.GetOrderStatus() == Domain.Enums.OrderStatus.Open)
            {
                var _productClient = _busControl.CreateRequestClient<ProductsRequest>(TimeSpan.FromSeconds(180));

                var itemsInOrder = await _productClient.GetResponse<ProductsResponse>(
                     new ProductsRequest() { Id = request.ProductID });

                var item = _mapper.Map<IEnumerable<Item>>(itemsInOrder.Message.Products);
                if (item != null)
                {
                    _basketLogic.AddItemToBasket(item.First());
                    return await Task.FromResult(new AddProductToBasketResposne() { ProductAdded = true });
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return await Task.FromResult(new AddProductToBasketResposne() { ProductAdded = false });
    }
}
