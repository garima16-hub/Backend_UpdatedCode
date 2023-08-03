using _3DModels.Models;
using _3DModels.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace _3DModels.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly string _jwtSecret;
        private readonly IConfiguration _configuration;
        private readonly AuthService _authService;
        private readonly ModelDbContext _context;
  

        public AuthController(IConfiguration configuration, ModelDbContext Context, AuthService authService)
        {
            _jwtSecret = configuration["ApplicationSettings:JWT_Secret"].ToString();
            _configuration = configuration;
            _authService = new AuthService(Context, configuration, _jwtSecret);
            _context = Context;
        }

        [HttpPost("login")]
        public IActionResult Login(UserRegistrationModel userRegistration)
        {
            // Authenticate the user and get the JWT token
            string token = _authService.Authenticate(userRegistration.Email, userRegistration.Pass);
            if (token == null)
            {
                return Unauthorized();
            }

            // Return the JWT token as the response
            return Ok(new { Token = token });
        }

        [HttpGet("admin-only-action")]
        [Authorize(Roles = "Admin")] // Only users with the "Admin" role can access this action
        public IActionResult AdminOnlyAction()
        {
            // Get the authenticated user's claims
            var user = HttpContext.User;

            // Check if the user has the "Admin" role claim
            if (user.Claims.Any(c => c.Type == System.Security.Claims.ClaimTypes.Role && c.Value == "Admin"))
            {
                // User has the "Admin" role, so allow access
                return Ok("This is an admin-only action.");
            }
            else
            {
                // User does not have the "Admin" role, return Unauthorized status
                return Unauthorized();
            }
        }

        [HttpGet("user-only-action")]
        [Authorize(Roles = "User")] // Only users with the "User" role can access this action
        public IActionResult UserOnlyAction()
        {
            // Get the authenticated user's claims
            var user = HttpContext.User;

            // Check if the user has the "User" role claim
            if (user.Claims.Any(c => c.Type == System.Security.Claims.ClaimTypes.Role && c.Value == "User"))
            {
                // User has the "User" role, so allow access
                return Ok("This is a user-only action.");
            }
            else
            {
                // User does not have the "User" role, return Unauthorized status
                return Unauthorized();
            }
        }
    }
}