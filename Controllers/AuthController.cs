using _3DModels.Models;
using _3DModels.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace _3DModels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly string _jwtSecret;
        //private readonly AuthService _authService;
        private readonly ModelDbContext _context;

        public AuthController(IConfiguration configuration, ModelDbContext context)
        {
            _jwtSecret = configuration["ApplicationSettings:JWT_Secret"].ToString();
            //_authService = authService;
            _context = context;
        }

    

        [HttpPost("login")]
        public IActionResult Login(UserRegistrationModel userRegistration)
        {
            // Authenticate the user
            var user = _context.users.SingleOrDefault(u => u.Email == userRegistration.Email);

            if (user == null || user.pass != userRegistration.Pass)
            {
                return Unauthorized();
            }

            // Generate and return a JWT token
            var token = GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        // Helper method to generate a JWT token
        private string GenerateJwtToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    //new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    //new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role) // Include the user's role in the token claims
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Set token expiration time as needed
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpGet("admin-only-action")]
        [Authorize(Roles = "Admin")] // Only users with the "Admin" role can access this action
        public IActionResult AdminOnlyAction()
        {
            var user = HttpContext.User;

            // Check if the user has the "Admin" role claim
            if (user.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "Admin"))
            {
                // User has the "Admin" role, so allow access

                try
                {
                    // Fetch data from the database
                    var data = _context.Models.ToList(); // Replace with your entity and data retrieval logic

                    // Perform admin operations
                    foreach (var entity in data)
                    {
                        // Example: Update properties of entities
                        entity.Price += 10;
                        entity.Title += " - " + entity.Description;
                        entity.Quantity = 10;



                        _context.Models.Remove(entity);
                    }

                    // Save changes to the database
                    _context.SaveChanges();

                    return Ok("Admin operations completed successfully.");
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to perform admin operations.");
                }
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
                var user = HttpContext.User;

                // Check if the user has the "User" role claim
                if (user.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "User"))
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

            [HttpGet("inventory-only-action")]
            [Authorize(Roles = "Inventory")] // Only users with the "Inventory" role can access this action
            public IActionResult InventoryOnlyAction()
            {
                var user = HttpContext.User;

                // Check if the user has the "Inventory" role claim
                if (user.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "Inventory"))
                {
                    // User has the "Inventory" role, so allow access

                    // Example: Get the model ID from the request query or route parameters
                    int modelId = 123; // Replace with your logic to get the model ID

                    // Example: Retrieve the model from the database
                    var model = _context.Models.FirstOrDefault(m => m.Id == modelId);

                    if (model == null)
                    {
                        return NotFound("Model not found.");
                    }

                    // Example: Update the model
                    model.Title = "Updated Title";
                    model.Description = "Updated Description";
                    // ... Update other properties as needed

                    try
                    {
                        _context.SaveChanges();
                        return Ok("Model updated successfully.");
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update model.");
                    }

                    // Example: Delete the model
                    _context.Models.Remove(model);
                    try
                    {
                        _context.SaveChanges();
                        return Ok("Model deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete model.");
                    }
                }
                else
                {
                    // User does not have the "Inventory" role, return Unauthorized status
                    return Unauthorized();
                }
            }

        }
    }

