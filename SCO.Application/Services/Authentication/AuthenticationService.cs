using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using SCO.Application.Common;
using SCO.Application.DTOs;
using SCO.Application.Exceptions;
using SCO.Domain.Entities;

namespace SCO.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly AuthenticationSettings _authentication;
    public AuthenticationService(IMapper mapper, IPasswordHasher<User> passwordHasher, AuthenticationSettings authentication)
    {
       
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _authentication = authentication;
    }

    public AuthenticationResult Login(LoginDto user)
    {
        var searchUser = new User(); //_restaurantDb.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == user.Email);
        if (searchUser is null)
        {
            throw new BadRequestException("Invalid user name or password");
        }

        var result = _passwordHasher.VerifyHashedPassword(searchUser, searchUser.PasswordHash, user.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new BadRequestException("Invalid user name or password");
        }

        var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, searchUser.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{ searchUser.Firstname }{searchUser.LastName}"),
                new Claim(ClaimTypes.Role, $"{ searchUser.Role.Name}"),
                new Claim("DateOfBirth", searchUser.DateOfBirth.Value.ToString("yyyy-MM-dd")),
            };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_authentication.JwtKey));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expires = DateTime.Now.AddDays(_authentication.JwtExpireDays);

        var token = new JwtSecurityToken(_authentication.JwtIssuer, _authentication.JwtIssuer,
            claims,
            expires: expires,
            signingCredentials: cred);

        var tokenHandler = new JwtSecurityTokenHandler();

        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            user.Email,
            tokenHandler.WriteToken(token));
    }

    public AuthenticationResult Login(string email, string password)
    {
        throw new NotImplementedException();
    }

    public AuthenticationResult Register(RegisterUserDto userDto)
    {
        var newUser = _mapper.Map<User>(userDto);
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