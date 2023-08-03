﻿using Microsoft.AspNetCore.Authorization;
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

namespace _3DModels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ModelDbContext _context;
        private readonly PasswordHashingService _passwordHashingService;

        public LoginController(IConfiguration configuration, ModelDbContext context, PasswordHashingService passwordHashingService)
        {
            _configuration = configuration;
            _context = context;
            _passwordHashingService = passwordHashingService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            if (login.Role == "Admin")
            {
                var currentUser = AdminConstants._admin.FirstOrDefault(
                    c => c.emailId.Equals(login.EmailID, StringComparison.OrdinalIgnoreCase)
                    && _passwordHashingService.VerifyPassword(login.Password, c.password)); // Verify hashed password

                if (currentUser != null)
                {
                    var token = GenerateToken(currentUser.emailId, "Administrator");
                    var response = new { Message = "Login successful", Token = token };
                    return Ok(response);
                }
            }
            else if (login.Role == "Buyer")
            {
                var buyer = _context.users
                    .AsEnumerable() // Switch to client-side evaluation
                    .FirstOrDefault(c => c.Email.Equals(login.EmailID, StringComparison.OrdinalIgnoreCase)
                        && _passwordHashingService.VerifyPassword(login.Password, c.pass)); // Verify hashed password

                if (buyer != null)
                {
                    var token = GenerateToken(buyer.Email, "Buyer");
                    var response = new { Message = "Login successful", Token = token };
                    return Ok(response);
                }
            }

            return BadRequest("User Not Found");
        }

        private string GenerateToken(string userEmail, string userRole)
        {
            var jwtSecret = _configuration["ApplicationSettings:JWT_Secret"];

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Email", userEmail),
                    new Claim(ClaimTypes.Role, userRole)
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
    }
}
