using AutoMapper;
using SCO.Identity.Application.Exceptions;
using SCO.Identity.Application.Common.Interfaces;

using SCO.Identity.Domain.Entities.Employees;
using SCO.Identity.Application.Authentication.Common;
using SCO.Indentity.Application.DTOs;

using Microsoft.AspNetCore.Identity;

namespace SCO.Identity.Application.Authentication.Commands;

public class AuthenticationQueryService : IAuthenticationQueryService
{

    private readonly IPasswordHasher<Cashier> _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationQueryService(IPasswordHasher<Cashier> passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
    {
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(LoginCashierDto user)
    {
        var searchUser = new Cashier(); //_restaurantDb.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == user.Email);
        if (searchUser is null)
        {
            throw new BadRequestException("Invalid user name or password");
        }

        var result = _passwordHasher.VerifyHashedPassword(searchUser, searchUser.PasswordHash, user.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new BadRequestException("Invalid user name or password");
        }

        var token = _jwtTokenGenerator.GenerateToken(searchUser.Id, searchUser.Firstname, searchUser.LastName, searchUser.Role.Name);
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            user.Email,
            token);
    }
}