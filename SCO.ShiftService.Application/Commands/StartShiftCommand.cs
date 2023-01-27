using MediatR;
using SCO.Contracts.Requests.Identity;
using SCO.Contracts.Responses.Shift;

namespace SCO.ShiftService.Application.Commands;

public record StartShiftCommand (LoginRequest Credential) : IRequest <StartShiftResponse>;

