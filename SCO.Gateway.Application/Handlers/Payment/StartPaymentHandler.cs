//using MassTransit;
//using MediatR;
//using SCO.Application.Commands;
//using SCO.Application.DTOs;
//using SCO.Contracts.Requests.Order;
//using SCO.Contracts.Requests.Payment;
//using SCO.Contracts.Responses;
//using SCO.Contracts.Responses.Payment;

//namespace SCO.Application.Handlers.Payment;

//public class StartPaymentHandler : IRequestHandler<StartPaymentCommand, PaymentResponse>
//{
//    private readonly IBusControl _busControl;

//    public StartPaymentHandler(IBusControl busControl)
//    {
//        _busControl = busControl;
//    }
//    public async Task<PaymentResponse> Handle(StartPaymentCommand request, CancellationToken cancellationToken)
//    {
//        var _basketClient =
//            _busControl.CreateRequestClient<OrderRequest>(TimeSpan.FromSeconds(180));

//        var itemsInOrder = _basketClient.GetResponse<OrderResponse>(
//             new OrderRequest(request.OrderId));

//        var _requestClient =
//          _busControl.CreateRequestClient<PaymentRequest>(TimeSpan.FromSeconds(180));

//        var response = _requestClient.GetResponse<PaymentResponse>(
//            new PaymentRequest(request.OrderId, itemsInOrder.Result.Message.Items));

//        return await Task.FromResult(response.Result.Message);
//    }
//}
