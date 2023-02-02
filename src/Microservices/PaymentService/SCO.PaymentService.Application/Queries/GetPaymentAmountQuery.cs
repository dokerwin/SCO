using MediatR;
using SCO.Contracts.DTOs;
using SCO.PaymentService.Application.DTOs;
using SCO.PaymentService.Domain.Enteties;

namespace SCO.PaymentService.Application.Queries
{
    public record  GetPaymentAmountQuery(IEnumerable<BasketItemDetailDto> Orders) : IRequest<PaymentAmountDto>;

}