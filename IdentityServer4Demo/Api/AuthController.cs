using IdentityServer4Demo.Models;
using IdentityServer4Demo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityServer4Demo.Api
{
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> RegisterUser([FromBody] SignupForm model)
        {
            var result = await _authService.RegisterUserAsync(model);

            return Ok(result);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _authService.GetUsersAsync();

            return Ok(result);
        }
    }
}