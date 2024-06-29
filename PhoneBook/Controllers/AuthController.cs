using Microsoft.AspNetCore.Mvc;
using PhoneBook.Model;
using PhoneBook.Services;

namespace PhoneBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(User userDto)
        {
            // Assume user is authenticated correctly
            var token = _tokenService.GenerateToken(userDto);
            return Ok(new { Token = token });
        }
    }
}
