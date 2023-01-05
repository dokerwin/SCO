using MediatR;
using SCO.Contracts.Identity;
using SCO.Contracts.Requests.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.Identity.Application.Authentication.Commands.RefreshToken;

public record RefreshTokenCommand(RefreshTokenRequest RefreshTokenRequest) : IRequest<AuthenticatedUserResponse>;