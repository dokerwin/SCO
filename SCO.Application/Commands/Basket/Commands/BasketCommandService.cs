using AutoMapper;
using MassTransit;
using SCO.Application.DTOs;
using SCO.Application.Services;
using SCO.Contracts.DTOs;
using SCO.Contracts.Requests.Order;
using SCO.Contracts.Requests.Product;
using SCO.Contracts.Responses;
using System.Text.Json;
using System.Xml.Linq;

namespace SCO.Application.Commands
{
    public class BasketCommandService : IBasketCommandService
    {
        private readonly IBusControl _busControl;
        private readonly IMapper _mapper;

        public BasketCommandService(IBusControl busControl, IMapper mapper)
        {
            _busControl = busControl;
            _mapper = mapper;
        }
        public void AddItemToBasket(ItemDto itemDto)
        {
            var _requestClient =
            _busControl.CreateRequestClient<AddItemOrderRequest>(TimeSpan.FromSeconds(10));

            var response = _requestClient.GetResponse<AddItemOrderResponse>(
                    new AddItemOrderRequest()
                    {
                        Item = itemDto
                    });
        }

        public void DeletItemFromBasket(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}