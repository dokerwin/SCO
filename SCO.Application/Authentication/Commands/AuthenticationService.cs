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

    public AuthenticationResult Register(RegisterUserDto userDto)
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