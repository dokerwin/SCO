using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using SCO.Application.Common;
using SCO.Application.DTOs;
using SCO.Application.Exceptions;
using SCO.Application.Common.Interfaces;
using SCO.Application.Services.Authentication.Common;
using SCO.Domain.Entities.Employees;

namespace SCO.Application.Services.Authentication.Commands;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IPasswordHasher<Cashier> _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationQueryService(IPasswordHasher<Cashier> passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
    {
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
  
    }

    public AuthenticationResult Login(LoginDto user)
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