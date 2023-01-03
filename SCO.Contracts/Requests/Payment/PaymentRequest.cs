using SCO.Contracts.DTOs;

namespace SCO.Contracts.Requests.Payment;

public record PaymentRequest (Guid OrderId, IEnumerable<ItemDto> Items);