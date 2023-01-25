using MediatR;
using SCO.Contracts.Requests.Identity;

namespace SCO.ShiftService.Application.Commands;

public record StartShiftCommand (LoginRequest Credential) : IRequest;

