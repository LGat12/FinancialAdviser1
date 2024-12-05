using Microsoft.AspNetCore.Mvc;
using FinancialAdviser.Models;
using FinancialAdviser.Services;

namespace FinancialAdviser.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel loginModel)
        {
            // Validate the login model
            if (loginModel == null || string.IsNullOrEmpty(loginModel.Email) || string.IsNullOrEmpty(loginModel.Password))
            {
                return BadRequest("Invalid login attempt.");
            }

            // Authenticate the user
            var user = await _userService.AuthenticateUserAsync(loginModel.Email, loginModel.Password);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            // Return the authenticated user
            return Ok(user);
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
