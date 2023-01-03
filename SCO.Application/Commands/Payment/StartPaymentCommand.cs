using MediatR;
using SCO.Contracts.Responses.Payment;

namespace SCO.Application.Commands;

public record StartPaymentCommand(Guid OrderId) : IRequest<PaymentResponse>;

