using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SCO.Contracts.Identity;
using SCO.Contracts.Responses.Identity;
using SCO.Identity.Aplications.Authentication.Authenticators;
using SCO.Identity.Application.Authentication.Commands.Login;
using SCO.Identity.Application.Authentication.Commands.Logout;
using SCO.Identity.Application.Common.Interfaces.Persistance;
using SCO.Identity.Application.Exceptions;

namespace SCO.Identity.Application.Authentication.Handlers;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, LogoutResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public LogoutCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
      
    }
    public async Task<LogoutResponse> Handle(LogoutCommand logout, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(logout.RawUserId, out Guid userId))
        {
            throw new BadRequestException("Invalid UserId");
        }

        await _unitOfWork.RefreshTokens.DeleteAll(userId);

        return await Task.FromResult(new LogoutResponse());
    }
}
