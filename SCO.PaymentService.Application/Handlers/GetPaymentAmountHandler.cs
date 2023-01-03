using MediatR;
using SCO.PaymentService.Application.DTOs;
using SCO.PaymentService.Application.Queries;

namespace SCO.PaymentService.Application.Handlers;

public class GetPaymentAmountHandler : IRequestHandler<GetPaymentAmountQuery, PaymentAmountDto>
{
    public async Task<PaymentAmountDto> Handle(GetPaymentAmountQuery request, CancellationToken cancellationToken)
    {
        double amount = request.Orders.Sum(s => s.Price);

        return await Task.FromResult(new PaymentAmountDto() { Amount = amount });
    }
}
