using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using _3DModels.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using NuGet.Protocol.Plugins;
using _3DModels.Services;
using Microsoft.EntityFrameworkCore;












namespace _3DModels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ModelDbContext _context;
        private readonly PasswordHashingService _passwordHashingService;





        public AuthController(IConfiguration configuration, ModelDbContext context, PasswordHashingService passwordHashingService)
        {
            _configuration = configuration;
            _context = context;
            _passwordHashingService = passwordHashingService;
        }





        [AllowAnonymous]
        [HttpPost]
        public IActionResult AuthLogin([FromBody] Login login)
        {
            if (login.Role == "Admin")
            {
                var Admin = _context.users
                     .AsEnumerable() // Switch to client-side evaluation
                     .FirstOrDefault(c => c.Email.Equals(login.EmailID, StringComparison.OrdinalIgnoreCase)
&& _passwordHashingService.VerifyPassword(login.Password, c.pass)); // Verify hashed password





                if (Admin != null)
                {
                    var token = GenerateToken(Admin.Email);
                    var response = new { Message = "Login successful", Token = token };
                    return Ok(response);
                }
            }





         return BadRequest("User Not Found");
      }


        [HttpGet("get-all-roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var distinctRoles = await _context.GetDistinctRolesAsync();
                return Ok(distinctRoles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve roles.");
            }
        }

        [HttpGet("admin-only-action")]
        [Authorize(Roles = "Admin")] // Only users with the "Admin" role can access this action
        public async Task<IActionResult> AdminOnlyAction()
        {
            // Ensure that the user has the required role
            if (!User.IsInRole("Admin"))
            {
                return Forbid(); // Return 403 Forbidden status
            }

            // Your admin-only logic here
            return Ok("Admin-only action accessed successfully.");
        }

        [HttpGet("user-only-action")]
        [Authorize(Roles = "User")] // Only users with the "User" role can access this action
        public IActionResult UserOnlyAction()
        {
            // Ensure that the user has the required role
            if (!User.IsInRole("User"))
            {
                return Forbid(); // Return 403 Forbidden status
            }

            // Your user-only logic here
            return Ok("User-only action accessed successfully.");
        }

        [HttpGet("inventory-only-action")]
        [Authorize(Roles = "Inventory")] // Only users with the "Inventory" role can access this action
        public IActionResult InventoryOnlyAction()
        {
            // Ensure that the user has the required role
            if (!User.IsInRole("Inventory"))
            {
                return Forbid(); // Return 403 Forbidden status
            }

            // Your inventory-only logic here
            return Ok("Inventory-only action accessed successfully.");
        }
        private async Task<Users> FetchUserFromDatabase(string email)
        {
            // Fetch user from your database based on the provided email
            // Implement your database retrieval logic here
            // You might use an ORM like Entity Framework or Dapper
            // Example using Entity Framework:
            return await _context.users.FirstOrDefaultAsync(u => u.Email == email);
        }
        private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            // In a real implementation, you would use a secure password hashing algorithm like BCrypt.
            // For the sake of simplicity, this example uses a basic string comparison.
            return enteredPassword == storedPasswordHash;
        }
    


    // ... Existing code for token generation and key generation ...   
    private string GenerateToken(string userEmail)
        {
            var jwtSecret = GenerateJwtSecretKey();





            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Email", userEmail)
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
                    SecurityAlgorithms.HmacSha256Signature)
            };





            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return token;
        }





        private string GenerateJwtSecretKey()
        {
            var randomBytes = new byte[32]; // 256 bits
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }
    }
}