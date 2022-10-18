using Microsoft.AspNetCore.Mvc;
using SCO.Application.Services;
using SCO.Application.DTOs;

namespace SCO.Api.Conrollers;
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto newUser)
        {
            _accountService.RegisterUser(newUser);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult LoginUser([FromBody] LoginDto user)
        {
           string token =  _accountService.GenerateJwt(user);
           return Ok(token);
        }
    }