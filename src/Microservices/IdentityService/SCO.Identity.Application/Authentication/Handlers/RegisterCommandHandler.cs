using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SCO.Contracts.Responses.Identity;
using SCO.Identity.Application.Authentication.Commands.Register;
using SCO.Identity.Application.Common.Interfaces.Persistance;
using SCO.Identity.Domain.Entities.Employees;

namespace SCO.Identity.Application.Authentication.Handlers;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    private readonly IPasswordHasher<Cashier> passwordHasher;

    public RegisterCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IPasswordHasher<Cashier> passwordHasher)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.passwordHasher = passwordHasher;
    }
    public async Task<RegisterResponse> Handle(RegisterCommand register, CancellationToken cancellationToken)
    {
        try
        {
            var registrationCashier = mapper.Map<Cashier>(register.RegisterRequest);

            registrationCashier.PasswordHash = passwordHasher.HashPassword(registrationCashier, register.RegisterRequest.Password);
            registrationCashier.Id = Guid.NewGuid();
            await unitOfWork.Cashiers.Add(registrationCashier);
            await unitOfWork.CompleteAsync();
            return await Task.FromResult(new RegisterResponse(true));
        }
        catch(Exception ex)
        {
            return await Task.FromResult(new RegisterResponse(false));
        }
        
    }
}
