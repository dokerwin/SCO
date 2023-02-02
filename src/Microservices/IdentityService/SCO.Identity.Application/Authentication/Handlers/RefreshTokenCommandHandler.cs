using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SCO.Contracts.Identity;
using SCO.Contracts.Responses.Identity;
using SCO.Identity.Aplications.Authentication.Authenticators;
using SCO.Identity.Aplications.Authentication.TokenValidators;
using SCO.Identity.Application.Authentication.Commands.RefreshToken;
using SCO.Identity.Application.Authentication.Commands.Register;
using SCO.Identity.Application.Common.Interfaces.Persistance;
using SCO.Identity.Application.Exceptions;
using SCO.Identity.Domain;
using SCO.Identity.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.Identity.Application.Authentication.Handlers;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthenticatedUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticator _authenticator;
    private readonly IRefreshTokenValidator _refreshTokenValidator;

    public RefreshTokenCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IAuthenticator authenticator,
        IRefreshTokenValidator refreshTokenValidator)
    {
        _unitOfWork = unitOfWork;
        _authenticator = authenticator;
        _refreshTokenValidator = refreshTokenValidator;
    }

    public async Task<AuthenticatedUserResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        string refreshToken = request.RefreshTokenRequest.RefreshToken;
        bool isValidRefreshToken = _refreshTokenValidator.Validate(refreshToken);
        if (!isValidRefreshToken)
        {
            throw new BadRequestException("Invalid refresh token");
        }

        RefreshToken refreshTokenDTO = await _unitOfWork.RefreshTokens.GetByToken(refreshToken);
        if (refreshTokenDTO == null)
        {
            throw new BadRequestException("Invalid refresh token");
        }

        await _unitOfWork.RefreshTokens.Delete(refreshTokenDTO.Id);

        Cashier user = await _unitOfWork.Cashiers.GetById(refreshTokenDTO.UserId);
        if (user == null)
        {
            throw new BadRequestException("User not found");
        }

        AuthenticatedUserResponse response = await _authenticator.Authenticate(user);

        return await Task.FromResult(response);
    }
}
