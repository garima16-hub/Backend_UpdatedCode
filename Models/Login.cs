using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _3DModels.Models
{
    public class Login
    {
        public string Role { get; set; }

        [Required(ErrorMessage = "Email ID is required.")]

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 16 characters.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character.")]
        public string Password { get; set; }
        
    }
}