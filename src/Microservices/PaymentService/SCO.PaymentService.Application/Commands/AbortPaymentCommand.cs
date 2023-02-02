using MediatR;
using SCO.Contracts.DTOs;
using SCO.PaymentService.Application.DTOs;

namespace SCO.PaymentService.Application.Commands;

public record AbortPaymentCommand(Guid OrderID) : IRequest<PaymentResultDto>;

