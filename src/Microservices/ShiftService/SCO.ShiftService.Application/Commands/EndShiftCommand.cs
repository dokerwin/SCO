using MediatR;
using SCO.Contracts.Requests.Identity;

namespace SCO.ShiftService.Application.Commands;

public record EndShiftCommand (LoginRequest Credential) : IRequest;

