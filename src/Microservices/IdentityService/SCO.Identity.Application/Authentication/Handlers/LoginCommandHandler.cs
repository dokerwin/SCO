using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SCO.Contracts.Identity;
using SCO.Contracts.Responses.Identity;
using SCO.Identity.Aplications.Authentication.Authenticators;
using SCO.Identity.Application.Authentication.Commands.Login;
using SCO.Identity.Application.Authentication.Commands.Register;
using SCO.Identity.Application.Common.Interfaces.Persistance;
using SCO.Identity.Application.Exceptions;
using SCO.Identity.Domain;
using SCO.Identity.Domain.Entities.Employees;

namespace SCO.Identity.Application.Authentication.Handlers;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticatedUserResponse>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    private readonly IPasswordHasher<Cashier> passwordHasher;
    private readonly IAuthenticator authenticator;

    public LoginCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IPasswordHasher<Cashier> passwordHasher, IAuthenticator authenticator)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.passwordHasher = passwordHasher;
        this.authenticator = authenticator;
    }
    public async Task<AuthenticatedUserResponse> Handle(LoginCommand login, CancellationToken cancellationToken)
    {
  
        var user = await unitOfWork.Cashiers.FindByEmailAsync(login.LoginRequest.Email);
       
        if (user is null)
        {
            throw new BadRequestException("Invalid user name or password");
        }

        user.Role = await unitOfWork.Roles.GetById(user.RoleId);
        var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, login.LoginRequest.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new BadRequestException("Invalid user name or password");
        }

        AuthenticatedUserResponse response = await authenticator.Authenticate(user);


        await unitOfWork.RefreshTokens.Add(new RefreshToken()
        {
            Id = Guid.NewGuid(),
            Token = response.AccessToken,
            UserId = user.Id,
        });

        await unitOfWork.CompleteAsync();

        return await Task.FromResult(response);
    }
}
