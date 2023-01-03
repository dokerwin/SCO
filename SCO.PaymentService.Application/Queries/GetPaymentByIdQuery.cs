using MediatR;
using SCO.PaymentService.Application.DTOs;
using SCO.PaymentService.Domain.Enteties;

namespace SCO.PaymentService.Application.Queries
{
    public record GetPaymentByIdQuery(Guid Id) : IRequest<PaymentDto>;

}