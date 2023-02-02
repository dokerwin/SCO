using MediatR;
using SCO.Contracts.Requests.Identity;
using SCO.Contracts.Responses.Identity;

namespace SCO.Identity.Application.Authentication.Commands.Register;

public record RegisterCommand(RegisterDto RegisterRequest) : IRequest<RegisterResponse>;