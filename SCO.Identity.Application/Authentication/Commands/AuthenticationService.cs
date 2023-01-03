using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using SCO.Identity.Application.Common;

using SCO.Identity.Application.Common.Interfaces;
using SCO.Identity.Domain.Entities.Employees;
using SCO.Indentity.Application.DTOs;
using SCO.Identity.Application.Authentication.Common;

namespace SCO.Identity.Application.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<Cashier> _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly AuthenticationSettings _authentication;

    public AuthenticationCommandService(IMapper mapper, IPasswordHasher<Cashier> passwordHasher)
    {
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public AuthenticationResult Register(RegisterCashierDto userDto)
    {
        var newUser = _mapper.Map<Cashier>(userDto);
        newUser.PasswordHash = _passwordHasher.HashPassword(newUser, userDto.Password);
        // _restaurantDb.Add(newUser);
        //_restaurantDb.SaveChanges();

        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            userDto.Email,
            "token");
    }
}