/*using _3DModels.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;



namespace _3DModels.Services
{

    public class AuthService
    {
        private readonly ModelDbContext _Context;
        private readonly string _secretKey;
        private readonly string _jwtSecret;
        private string? jwtSecret;


        public AuthService(ModelDbContext Context, IConfiguration configuration, string jwtSecret)
        {
            _Context = Context;
            _secretKey = configuration["ApplicationSettings:JWT_Secret"]; ;
            _jwtSecret = jwtSecret;
        }

        public AuthService(string jwtSecret)
        {
            this.jwtSecret = jwtSecret;
        }

        public string GenerateJwtToken(int userId, string username, string[] roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("user_id", userId.ToString()),
                    new Claim("username", username),
                    // Add more claims like roles or other user-related information here
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Set token expiration time as needed
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private bool VerifyPasswordHash(string password, string passwordHash)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hashedPassword == passwordHash;
            }
        }



        public string Authenticate(string email, string pass)
        {
            var user = _Context.users.SingleOrDefault(u => u.Email == email);
            if (user == null || !VerifyPasswordHash(pass, user.pass))
            {
                return null; // Authentication failed
            }

            // Authentication successful, create JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.user_id.ToString()),
                new Claim(ClaimTypes.Name, user.username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role) // Include the user's role in the token claims
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time (adjust as needed)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        
            public bool ValidateUserCredentials(string userEmail, string password)
            {
                // Your authentication logic here
                // For example, you can check if the provided email and password match a user in the database.
                // Return true if the user credentials are valid, otherwise return false.

                // Example (replace with your actual logic):
                var user = _Context.users.SingleOrDefault(u => u.Email == userEmail);
                if (user != null)
                {
                    return VerifyPasswordHash(password, user.pass);
                }
                return false;
            }

          
        }


        


        
    }
*/


