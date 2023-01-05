using MediatR;
using SCO.Contracts.Responses.Identity;

namespace SCO.Identity.Application.Authentication.Commands.Logout;

public record LogoutCommand (string RawUserId) : IRequest<LogoutResponse>;
