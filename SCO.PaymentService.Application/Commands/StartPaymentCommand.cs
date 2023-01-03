using MediatR;
using SCO.Contracts.DTOs;
using SCO.PaymentService.Application.DTOs;

namespace SCO.PaymentService.Application.Commands;

public record StartPaymentCommand(Guid OrderID, IEnumerable<ItemDto> Items) : IRequest<PaymentResultDto>;

